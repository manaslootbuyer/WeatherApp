using Refit;
using Weather.Domain.Models;
using Weather.Services.Contracts;

namespace Weather.Services.RestApi
{
	public interface IWeatherApi
	{
        [Get("/forecast")]
        Task<WeatherModel> GetCurrentWeatherAndHourlyForecastByLatLon(WeatherContract weatherContract);
    }
}

