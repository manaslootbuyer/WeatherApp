using System;
using Autofac;
using Weather.Core.Navigation;
using Weather.Domain.Navigation;

namespace Weather.UI.Modules
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<AppDialogService>().As<IAppDialogService>().SingleInstance();
        }
    }
}

