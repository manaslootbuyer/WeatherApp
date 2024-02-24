using System.Diagnostics.CodeAnalysis;
using Weather.Core.DialogModels;

namespace Weather.UI.Dialogs;

[ExcludeFromCodeCoverage]
public partial class AlertDialog
{
    public AlertDialog()
    {
        InitializeComponent();
    }
}
[ExcludeFromCodeCoverage]
public class AlertDialogXaml : DialogBase<AlertDialogModel>
{

}
