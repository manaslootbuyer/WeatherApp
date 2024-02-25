using System;
using Weather.UI.Enums;

namespace Weather.UI.Extensions
{
    public static class IntExtensions
    {
        public static WeatherConditionEnum ToCondition(this int value)
        {
            switch (value)
            {
                case 0:
                    return WeatherConditionEnum.Clear;
                case 1:
                case 2:
                case 3:
                case 45:
                case 48:
                    return WeatherConditionEnum.Cloudy;
                case 51:
                case 53:
                case 55:
                case 56:
                case 57:
                case 61:
                case 63:
                case 65:
                case 66:
                case 67:
                case 80:
                case 81:
                case 82:
                case 95:
                case 96:
                case 99:
                    return WeatherConditionEnum.Rainy;
                case 71:
                case 73:
                case 75:
                case 77:
                case 85:
                case 86:
                    return WeatherConditionEnum.Snowy;
                default:
                    return WeatherConditionEnum.Unknown;
            }
        }
    }
}

