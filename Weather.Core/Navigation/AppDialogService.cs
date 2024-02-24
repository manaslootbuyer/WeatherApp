using System;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;
using Weather.Domain.Navigation;
using Weather.Domain.Navigation.Params;
using CommunityToolkit.Maui.Views;
using WeatherApp.Common.Constant;

namespace Weather.Core.Navigation
{
    [ExcludeFromCodeCoverage]
    public class AppDialogService : IAppDialogService
    {
        private readonly IPageResolver _pageFactory;
        private readonly IBindingLifeCycleHandler _bindingLifeCycleHandler;
        private readonly IPopupNavigation _popupNavigation;
        private readonly ILogger<AppDialogService> _logger;

        public AppDialogService(
            IPageResolver pageFactory,
            IPopupNavigation popupNavigation,
            IBindingLifeCycleHandler bindingLifeCycleHandler,
            ILogger<AppDialogService> logger)
        {
            _pageFactory = pageFactory;
            _bindingLifeCycleHandler = bindingLifeCycleHandler;
            _popupNavigation = popupNavigation;
            _logger = logger;
        }

        public async Task ShowLoading()
        {
            await ShowLoading("Loading");
        }

        public async Task ShowLoading(string message)
        {
            var loadings = _popupNavigation.PopupStack
                .Where(x => x.BindingContext is ILoading)
                .ToList();

            if (loadings.Count > 0)
            {
                if (loadings.First().BindingContext is ILoading loading)
                {
                    loading.UpdateMessage(message);
                }
            }
            else
            {
                await ShowPopupPage(ViewNames.LoadingDialog, message, false);
            }
        }

        public async Task HideLoading()
        {
            await CloseLoadingPage();
        }

        private async Task CloseLoadingPage()
        {
            try
            {
                var loadings = _popupNavigation.PopupStack
                    .Where(x => x.BindingContext is ILoading)
                    .ToList();

                foreach (var currentPage in loadings.OfType<Popup>())
                {
                    _bindingLifeCycleHandler.CleanUpPageViewModel(currentPage);

                    _popupNavigation.ClosePopup(currentPage);

                }

                _logger.LogInformation("Closed Loading Page");
            }
            catch (Exception ex)
            {
                await ShowWarningAsync(ex.Message);
            }
        }

        public async Task ShowWarningAsync(string message)
        {
            await ShowPopupPage(ViewNames.AlertDialog, message, false);

            _logger.LogInformation("Showed Warning: {Message}", message);
        }

        public async Task ShowWarningAsync(IMessageTitleParam param)
        {
            await ShowPopupPage(ViewNames.AlertDialog, param, false);

            _logger.LogInformation("Showed Warning: {Title} - {Message}", param.Title, param.Message);
        }

        public async Task ShowCustomWarningParam(string viewName, ICustomMessageParam param)
        {
            await ShowPopupPage(viewName, param, false);

            _logger.LogInformation("Showed Warning: {Title} - {Message}", param.Title, param.Message);
        }

        public async Task<bool> ShowConfirmAsync(IConfirmParam param)
        {
            var confirmFinished = new TaskCompletionSource<bool>();

            param.ConfirmationCompleted += (_, b) => { confirmFinished.TrySetResult(b); };

            await ShowPopupPage(ViewNames.ConfirmDialog, param, false);

            _logger.LogInformation("Showed Confirm: {Title} - {Message}", param.Message, param.Title);

            var result = await confirmFinished.Task;

            _logger.LogInformation("Answered Confirm: {Result}", result);

            await ClosePopupPage();

            return result;
        }

        public async Task ShowPopupPage(string popupName, bool isAnimated = true)
        {
            try
            {
                var page = ShowPopup(popupName);

                await _bindingLifeCycleHandler.InitializePageViewModel(page);

                _logger.LogInformation("Showed Popup Page: {PopupName}", popupName);
            }
            catch (PageNotYetImplementedException ex)
            {
                await ShowWarningAsync(ex.Message);
            }
        }

        public async Task ShowPopupPage<T>(string popupName, T? param, bool isAnimated = true)
        {
            try
            {
                var page = ShowPopup(popupName);

                await _bindingLifeCycleHandler.InitializePageViewModel(page, param);

                _logger.LogInformation("Showed Popup Page: {PopupName}", popupName);
            }
            catch (PageNotYetImplementedException ex)
            {
                await ShowWarningAsync(ex.Message);
            }
        }

        private Popup ShowPopup(string popupName)
        {
            var page = _pageFactory.GetPopupPageWithAttachedViewModel(popupName);

            _popupNavigation.ShowPopup(page);

            return page;
        }

        public async Task ClosePopupPage()
        {
            try
            {
                var currentPage = _popupNavigation.PopupStack.Last();

                _bindingLifeCycleHandler.CleanUpPageViewModel(currentPage);

                _popupNavigation.ClosePopup(currentPage);

                _logger.LogInformation("Closed Current Popup Page");
            }
            catch (Exception ex)
            {
                await ShowWarningAsync(ex.Message);
            }
        }
    }
}

