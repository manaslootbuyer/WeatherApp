using Microsoft.Extensions.Logging;
using Weather.Domain.Navigation;

namespace Weather.Core.Navigation
{
    public class NavigationService : INavigationService
    {
        private readonly IPageResolver _pageResolver;
        private readonly IBindingLifeCycleHandler _bindingLifeCycleHandler;
        private readonly IAppDialogService _dialogService;
        private readonly ILogger<NavigationService> _logger;

        public NavigationService(NavigationPage navigationPage,
            IPageResolver pageResolver,
            IBindingLifeCycleHandler bindingLifeCycleHandler,
            IAppDialogService dialogService,
            ILogger<NavigationService> logger)
        {
            _pageResolver = pageResolver;
            _bindingLifeCycleHandler = bindingLifeCycleHandler;
            _dialogService = dialogService;
            _logger = logger;

            NavigationRootView = navigationPage;

            AttachPopEvents();
        }

        private NavigationPage NavigationRootView { get; }
        private Page CurrentPage => NavigationRootView.CurrentPage;

        public async Task PopAsync()
        {
            await NavigationRootView.PopAsync(true);
            _logger.LogInformation("Navigated Back to Previous Page");
        }

        public async Task PushAsync(string viewName)
        {
            try
            {
                var page = await PushPageAsync(viewName);
                await _bindingLifeCycleHandler.InitializePageViewModel(page);
            }
            catch (PageNotYetImplementedException)
            {
                await _dialogService.ShowWarningAsync($"Page {viewName} not yet implemented.");
            }
            catch (Exception ex)
            {
                //todo: logger extensions
                //_logger.AuditLogError(ex);
                await _dialogService.ShowWarningAsync(ex.Message);
                await PopAsync();
            }
            finally
            {
                await _dialogService.HideLoading();
            }
        }

        public async Task PushAsync<T>(string viewName, T parameter)
        {
            try
            {
                var page = await PushPageAsync(viewName);
                await _bindingLifeCycleHandler.InitializePageViewModel(page, parameter);
            }
            catch (PageNotYetImplementedException)
            {
                await _dialogService.ShowWarningAsync($"Page {viewName} not yet implemented.");
            }
            catch (Exception ex)
            {
                //todo: logger extensions
                //_logger.AuditLogError(ex);
                await _dialogService.ShowWarningAsync(ex.Message);
                await PopAsync();
            }
        }

        private async Task<Page> PushPageAsync(string viewName)
        {
            var page = GetPage(viewName);
            await NavigationRootView.PushAsync(page, true);
            _logger.LogInformation("Navigated to page: {ViewName}", viewName);
            return page;
        }

        public async Task PushToNewRootPage(string viewName)
        {
            try
            {
                var page = await PushNewRootPage(viewName);
                await _bindingLifeCycleHandler.InitializePageViewModel(page);
            }
            catch (PageNotYetImplementedException)
            {
                await _dialogService.ShowWarningAsync($"Page {viewName} not yet implemented.");
            }
        }

        public async Task PushToNewRootPage<T>(string viewName, T parameter)
        {
            try
            {
                var page = await PushNewRootPage(viewName);
                await _bindingLifeCycleHandler.InitializePageViewModel(page, parameter);
            }
            catch (PageNotYetImplementedException)
            {
                await _dialogService.ShowWarningAsync($"Page {viewName} not yet implemented.");
            }
            catch (NotInitializableException ex)
            {
                await _dialogService.ShowWarningAsync(ex.Message);

                await PopAsync();
            }
        }

        private async Task<Page> PushNewRootPage(string viewName)
        {
            try
            {
                DetachPopEvents();
                var page = GetPage(viewName);
                NavigationRootView.Navigation.InsertPageBefore(page, NavigationRootView.RootPage);
                await PopToRootAsync();
                _logger.LogInformation("Navigated to new root page: {ViewName}", viewName);
                return page;
            }
            finally
            {
                AttachPopEvents();
            }
        }

        public async Task PopToRootAsync()
        {
            CleanUpAllExceptRootPageViewModel();
            await NavigationRootView.PopToRootAsync();
        }


        private void CleanUpAllExceptRootPageViewModel()
        {
            var nonRootPages =
                NavigationRootView.Navigation.NavigationStack.Where(x => x != NavigationRootView.RootPage);
            foreach (var page in nonRootPages)
            {
                _bindingLifeCycleHandler.CleanUpPageViewModel(page);
            }
        }

        private Page GetPage(string viewName)
        {
            return _pageResolver.GetPageWithAttachedViewModel(viewName);
        }

        private void AttachPopEvents()
        {
            NavigationRootView.Popped += NavigationRootView_Popped;
            NavigationRootView.PoppedToRoot += NavigationRootView_PoppedToRoot;
        }

        private void DetachPopEvents()
        {
            NavigationRootView.Popped -= NavigationRootView_Popped;
            NavigationRootView.PoppedToRoot -= NavigationRootView_PoppedToRoot;
        }

        private void NavigationRootView_PoppedToRoot(object? sender, NavigationEventArgs e)
        {
            if (CurrentPage.BindingContext is IBusy busy)
            {
                busy.IsBusy = false;
            }
        }

        private void NavigationRootView_Popped(object? sender, NavigationEventArgs e)
        {
            _bindingLifeCycleHandler.CleanUpPageViewModel(e.Page);
            _bindingLifeCycleHandler.NotifyPageWhenBackNavigated(CurrentPage);
        }
    }
}

