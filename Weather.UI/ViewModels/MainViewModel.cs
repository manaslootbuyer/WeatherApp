using Weather.Core.Base;
using Weather.Domain.Models;
using Weather.Domain.Navigation;
using Weather.Services.Contracts;
using Weather.Services.Services;

namespace Weather.UI.ViewModels
{
    public class MainViewModel : ViewModel, IInitializeAsync
    {
        private readonly INavigationService _navigationService;
        private readonly IAppDialogService _appDialogService;
        private readonly IWeatherService _weatherService;
        private double _latitude;
        private double _longitude;

        public MainViewModel(INavigationService navigationService,
            IAppDialogService appDialogService,
            IWeatherService weatherService)
        {
            _navigationService = navigationService;
            _appDialogService = appDialogService;
            _weatherService = weatherService;

        }

        private DateTime _currentDate = DateTime.Now;
        public DateTime CurrentDate
        {
            get => _currentDate;
            set => SetProperty(ref _currentDate, value);
        }

        private double _currentTemp;
        public double CurrentTemp
        {
            get => _currentTemp;
            set => SetProperty(ref _currentTemp, value);
        }

        private int _dayCode;
        public int DayCode
        {
            get => _dayCode;
            set => SetProperty(ref _dayCode, value);
        }

        private string _city;
        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        private int _weatherCondition;
        public int WeatherCondition
        {
            get => _weatherCondition;
            set => SetProperty(ref _weatherCondition, value);
        }

        private List<CurrentWeatherModel> _dailyWeatherList= new List<CurrentWeatherModel>();
        public List<CurrentWeatherModel> DailyWeatherList
        {
            get => _dailyWeatherList;
            set => SetProperty(ref _dailyWeatherList, value);
        }

        public async Task InitializeAsync()
        {
            await _appDialogService.ShowLoading();

            var location = await Geolocation.GetLocationAsync();
            if (location != null)
            {
                _latitude = location.Latitude;
                _longitude = location.Longitude;
            }

            var placemarks = await Geocoding.GetPlacemarksAsync(_latitude, _longitude);

            if (placemarks != null && placemarks.Any())
            {
                var placemark = placemarks.FirstOrDefault();
                if (placemark != null)
                {
                    string country = placemark.CountryName;
                    City = placemark.Locality;
                }
            }

            var result = await _weatherService.GetCurrentWeatherAndHourlyForecastByLatLon(new WeatherContract
            {
                Latitude = _latitude,
                Longitude = _longitude,
            });

            CurrentTemp = result?.CurrentWeather?.Temperature ?? 0;
            WeatherCondition = result?.CurrentWeather?.Weathercode ?? 0;
            DayCode = result?.CurrentWeather?.IsDay ?? 1;

            if(result?.ForcastWeather != null)
            {
                DailyWeatherList = result.ForcastWeather;
            }

            await _appDialogService.HideLoading();
        }

    }
}

