using System;
using Weather.Domain.Models;
using Weather.Services.Contracts;

namespace Weather.Services.Services
{
	public interface IWeatherService
	{
        Task<WeatherModel> GetCurrentWeatherAndHourlyForecastByLatLon(WeatherContract weatherContract);
    }
}

