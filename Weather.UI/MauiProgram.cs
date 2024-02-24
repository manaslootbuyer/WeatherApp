using Autofac.Extensions.DependencyInjection;
using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Weather.Core;

namespace Weather.UI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
            .UseMauiCommunityToolkit()
            .UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
                fonts.AddFont("NunitoSans.ttf", "NunitoSans");
                fonts.AddFont("NunitoSans-Regular.ttf", "NunitoSansRegular");
                fonts.AddFont("NunitoSans-SemiBold.ttf", "NunitoSansSemiBold");
                fonts.AddFont("NunitoSans-Bold.ttf", "NunitoSansBold");
                fonts.AddFont("NunitoSans-ExtraBold.ttf", "NunitoSansExtraBold");
                fonts.AddFont("fasolid.ttf", "FontAwesomeSolidFontFamily");
                fonts.AddFont("faregular.ttf", "FontAwesomeRegularFontFamily");
            }).ConfigureContainer(
                new AutofacServiceProviderFactory(),
                AutofacBootstrapper.RegisterAutofacModule); ;

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

