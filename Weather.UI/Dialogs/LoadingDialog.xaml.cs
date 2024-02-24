using System.Diagnostics.CodeAnalysis;
using Weather.Core.DialogModels;

namespace Weather.UI.Dialogs;

[ExcludeFromCodeCoverage]
public partial class LoadingDialog
{
    public LoadingDialog()
    {
        InitializeComponent();
    }
}

[ExcludeFromCodeCoverage]
public class LoadingDialogXaml : DialogBase<LoadingDialogModel>
{

}