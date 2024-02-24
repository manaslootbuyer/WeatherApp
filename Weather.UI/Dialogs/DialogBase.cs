using System;
using CommunityToolkit.Maui.Views;
using System.Diagnostics.CodeAnalysis;
using Weather.Domain.Navigation;

namespace Weather.UI.Dialogs
{
    [ExcludeFromCodeCoverage]
    public abstract class DialogBase : Popup, IViewModelTypeExposed
    {
        protected DialogBase()
        {
            CanBeDismissedByTappingOutsideOfPopup = false;
        }

        public abstract Type ViewModelType { get; }

    }

    [ExcludeFromCodeCoverage]
    public abstract class DialogBase<T> : DialogBase
    {
        public override Type ViewModelType => typeof(T);

    }
}