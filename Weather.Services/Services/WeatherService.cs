using System;
using Refit;
using System.Net;
using Weather.Common.Constant;
using Weather.Domain.Models;
using Weather.Services.Contracts;
using Weather.Services.RestApi;
using Weather.Common.Exceptions;

namespace Weather.Services.Services
{
    public class WeatherService : IWeatherService
	{
        private  IWeatherApi _weatherApi;

        public WeatherService()
        {

        }
        private void Initialize()
        {
            _weatherApi = HttpClientProvider.Instance.GetApi<IWeatherApi>(Server.ApiUrl);
        }

        public async Task<WeatherModel> GetCurrentWeatherAndHourlyForecastByLatLon(WeatherContract weatherContract)
        {
            try
            {
                Initialize();
                var response = await _weatherApi.GetCurrentWeatherAndHourlyForecastByLatLon(weatherContract);
                response.ForcastWeather = GetFakeForecast();
                return response;
            }
            catch (ApiException apiException)
            {
                if (apiException.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new ServerErrorException();
                }

                return null;
            }
        }

        public List<CurrentWeatherModel> GetFakeForecast()
        {
            List<CurrentWeatherModel> weatherList = new List<CurrentWeatherModel>();
            DateTime startDate = DateTime.Now;
            var availableCases = new int[]
            {
                0, 1, 2, 3, 45, 48, 51, 53, 55, 56, 57, 61, 63, 65, 66, 67, 80, 81, 82, 95, 96, 99, 71, 73, 75, 77, 85, 86
            };
            Random random = new Random();
          
            for (int i = 0; i < 10; i++)
            {
                DateTime currentTime = startDate.AddDays(i);
                int randomIndex = random.Next(availableCases.Length);
                int randomNumber = availableCases[randomIndex];
                CurrentWeatherModel weather = new CurrentWeatherModel
                {
                    Time = currentTime,
                    Interval = 900,
                    Temperature = random.Next(10, 36),
                    Windspeed = 3.4,
                    Winddirection = 238,
                    IsDay = 1,
                    Weathercode = randomNumber
                };
                weatherList.Add(weather);
            }

            return weatherList;
        }
    }
}

