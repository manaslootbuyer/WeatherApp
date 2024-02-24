using System.Diagnostics.CodeAnalysis;
using Weather.Domain.Navigation;

namespace Weather.UI.Views;

[ExcludeFromCodeCoverage]
public abstract class AppContentPageBase : ContentPage, IViewModelTypeExposed
{
    protected AppContentPageBase()
    {
        //Uncomment this if you need to implement custom navigation bar.
        NavigationPage.SetHasNavigationBar(this, false);
        NavigationPage.SetHasBackButton(this, true);
    }

    public abstract Type ViewModelType { get; }

    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}

[ExcludeFromCodeCoverage]
public abstract class AppContentPageBase<T> : AppContentPageBase
{
    public override Type ViewModelType => typeof(T);
}

[ExcludeFromCodeCoverage]
public abstract class AppFlyoutPageBase : FlyoutPage, IViewModelTypeExposed
{
    protected AppFlyoutPageBase()
    {
        //Uncomment this if you need to implement custom navigation bar.
        NavigationPage.SetHasNavigationBar(this, false);
        NavigationPage.SetHasBackButton(this, true);
    }

    public abstract Type ViewModelType { get; }

    protected override bool OnBackButtonPressed()
    {
        return true;
    }
}

[ExcludeFromCodeCoverage]
public abstract class AppFlyoutPageBase<T> : AppFlyoutPageBase
{
    public override Type ViewModelType => typeof(T);
}