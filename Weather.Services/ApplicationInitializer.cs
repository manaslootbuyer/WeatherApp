using System;
using Weather.Domain.Navigation;
using WeatherApp.Common.Constant;

namespace Weather.Services
{
    public class ApplicationInitializer : IApplicationInitializer
    {
        private readonly INavigationService _navigationService;

        public ApplicationInitializer(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public void StartApplication()
        {
            _navigationService.PushAsync(ViewNames.MainPage);
        }
    }
}

