using System.Diagnostics.CodeAnalysis;
using Weather.UI.ViewModels;
using Weather.UI.Views;

namespace Weather.UI;

[ExcludeFromCodeCoverage]
public partial class MainPage
{
	public MainPage()
	{
		InitializeComponent();
	}
}

[ExcludeFromCodeCoverage]
public class MainPageXaml : AppContentPageBase<MainViewModel>
{
}


