using System;
using Newtonsoft.Json;
using Refit;

namespace Weather.Services.Contracts
{
	public class WeatherContract
	{
        [AliasAs("latitude")]
        public double Latitude { get; set; }

        [AliasAs("longitude")]
        public double Longitude { get; set; }

        [AliasAs("current_weather")]
        public bool CurrentWeather => true;
    }
}

