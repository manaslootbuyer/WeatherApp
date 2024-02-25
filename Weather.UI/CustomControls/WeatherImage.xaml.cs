
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Weather.UI.Enums;
using Weather.UI.Extensions;

namespace Weather.UI.CustomControls;
[ExcludeFromCodeCoverage]
public partial class WeatherImage
{
    public static readonly BindableProperty WeatherCodeProperty
      = BindableProperty.Create(nameof(WeatherCode), typeof(int), typeof(int), 0);

    public static readonly BindableProperty DayCodeProperty
      = BindableProperty.Create(nameof(DayCode), typeof(int), typeof(WeatherImage), 0);

    public WeatherImage()
	{
		InitializeComponent();
        WeatherImageControl.Source ="icon_01n";
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
        if(propertyName == nameof(WeatherCode) || propertyName == nameof(DayCode))
        {
            var weatherCondition = WeatherCode.ToCondition();
            switch (weatherCondition)
            {
                case WeatherConditionEnum.Clear:
                    WeatherImageControl.Source = IsDay ? "icon_01d" : "icon_01n";
                    break;
                case WeatherConditionEnum.Cloudy:
                    WeatherImageControl.Source = IsDay ? "icon_01d" : "icon_02n";
                    break;
                case WeatherConditionEnum.Rainy:
                    WeatherImageControl.Source = IsDay ? "icon_10d" : "icon_10n";
                    break;
                case WeatherConditionEnum.Snowy:
                    WeatherImageControl.Source = IsDay ? "icon_13n" : "icon_13n_n";
                    break;
                case WeatherConditionEnum.Unknown:
                    WeatherImageControl.Source = IsDay ? "icon_50d" : "icon_50n";
                    break;
            }
        }
    }


    public int WeatherCode
    {
        get => (int)GetValue(WeatherCodeProperty);
        set => SetValue(WeatherCodeProperty, value);
    }

    public int DayCode
    {
        get => (int)GetValue(DayCodeProperty);
        set => SetValue(DayCodeProperty, value);
    }

    public bool IsDay => DayCode == 1;

}
