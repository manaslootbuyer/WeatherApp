using System.Diagnostics.CodeAnalysis;

namespace Weather.Core.Navigation
{
    [ExcludeFromCodeCoverage]
    public class CustomNavigationPage : NavigationPage
    {
        public CustomNavigationPage() : base(new ContentPage())
        {
            IconImageSource = null;
        }
    }
}

