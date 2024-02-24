using Weather.Domain.Navigation;

namespace Weather.UI;

public partial class App : Application
{
    private readonly IApplicationInitializer _applicationInitializer;

    public App(NavigationPage navigationPage,
        IApplicationInitializer applicationInitializer)
    {
        InitializeComponent();

        _applicationInitializer = applicationInitializer;
        MainPage = navigationPage;
    }

    protected override void OnStart()
    {
        base.OnStart();

        _applicationInitializer.StartApplication();
    }
}

