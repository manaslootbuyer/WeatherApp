using System;
using Autofac;
using Weather.Core.Navigation;
using Weather.Domain.Navigation;
using Weather.Services;
using Weather.Services.RestApi;
using Weather.Services.Services;

namespace Weather.UI.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<AppDialogService>().As<IAppDialogService>().SingleInstance();
            builder.Register(c => HttpClientProvider.Instance.GetApi<IWeatherApi>()).As<IWeatherApi>();
            builder.RegisterType<WeatherService>().As<IWeatherService>().SingleInstance();
        }
    }
}

