using CommunityToolkit.Maui.Views;
namespace Weather.Core.Navigation
{
    public interface IPopupNavigation
    {
        IEnumerable<Popup> PopupStack { get; }
        Task ShowPopupAsync(Popup popup);
        void ClosePopup(Popup popup);
        void ShowPopup(Popup popup);
    }
}

