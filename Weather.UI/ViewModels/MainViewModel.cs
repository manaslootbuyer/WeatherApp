using Weather.Core.Base;
using Weather.Domain.Navigation;

namespace Weather.UI.ViewModels
{
    public class MainViewModel : ViewModel, IInitializeAsync
    {
        private readonly INavigationService _navigationService;
        private readonly IAppDialogService _appDialogService;

        public MainViewModel(INavigationService navigationService,
            IAppDialogService appDialogService)
        {
            _navigationService = navigationService;
            _appDialogService = appDialogService;
        }
        public Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
    }
}

