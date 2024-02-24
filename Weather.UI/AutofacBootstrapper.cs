using Autofac;
using Weather.UI.Modules;

namespace Weather.UI
{
    public abstract class AutofacBootstrapper
    {
        public static void RegisterAutofacModule(ContainerBuilder? builder = null)
        {
            var containerBuilder = builder ?? new ContainerBuilder();

            containerBuilder.RegisterModule(new ServiceModule());

            containerBuilder.RegisterModule(new PageModule());
        }
    }
}

