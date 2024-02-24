using Autofac;
using CommunityToolkit.Maui.Views;
using Weather.Core.DialogModels;
using Weather.Core.Navigation;
using Weather.Domain.Navigation;
using Weather.Services;
using Weather.UI.Dialogs;
using Weather.UI.ViewModels;
using WeatherApp.Common.Constant;

namespace Weather.UI.Modules
{
    public class PageModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomNavigationPage>()
                .As<NavigationPage>()
                .SingleInstance();

            builder.RegisterType<ApplicationInitializer>()
                .As<IApplicationInitializer>()
                .SingleInstance();

            builder.RegisterType<PageResolver>()
                .As<IPageResolver>()
                .SingleInstance();

            builder.RegisterType<NavigationService>()
                .As<INavigationService>()
                .SingleInstance();

            builder.RegisterType<BindingLifeCycleHandler>()
                .As<IBindingLifeCycleHandler>()
                .SingleInstance();

            builder.RegisterType<PopupNavigation>()
             .As<IPopupNavigation>()
             .SingleInstance();

            builder.RegisterType<MainPage>()
                 .Named<Page>(ViewNames.MainPage)
                  .InstancePerDependency();

            builder.RegisterType<MainViewModel>().InstancePerDependency();

            RegisterDialogs(builder);
        }

        private static void RegisterDialogs(ContainerBuilder builder)
        {
            builder.RegisterType<AlertDialogModel>().InstancePerDependency();

            builder.RegisterType<LoadingDialogModel>().InstancePerDependency();

            builder.RegisterType<AlertDialog>().Named<Popup>(ViewNames.AlertDialog)
                .AsImplementedInterfaces().InstancePerDependency();

            builder.RegisterType<LoadingDialog>().Named<Popup>(ViewNames.LoadingDialog)
                .AsImplementedInterfaces().InstancePerDependency();
        }
    }
}

