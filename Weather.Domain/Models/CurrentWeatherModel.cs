using Refit;

namespace Weather.Domain.Models
{
    public class CurrentWeatherModel 
    {
        [AliasAs("time")]
        public DateTime Time { get; set; }

        [AliasAs("interval")]
        public int Interval { get; set; }

        [AliasAs("temperature")]
        public double Temperature { get; set; }

        [AliasAs("windspeed")]
        public double Windspeed { get; set; }

        [AliasAs("winddirection")]
        public int Winddirection { get; set; }

        [AliasAs("is_day")]
        public int IsDay { get; set; }

        [AliasAs("weathercode")]
        public int Weathercode { get; set; }
    }

}

