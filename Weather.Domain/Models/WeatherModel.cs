using System;
using Newtonsoft.Json;
using Refit;

namespace Weather.Domain.Models
{

    public class WeatherModel
    {
        [AliasAs("latitude")]
        public double Latitude { get; set; }

        [AliasAs("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("current_weather")]
        public CurrentWeatherModel CurrentWeather { get; set; }

        public List<CurrentWeatherModel> ForcastWeather { get; set; }
    }

}

