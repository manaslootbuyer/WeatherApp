using CommunityToolkit.Maui.Views;

namespace Weather.Domain.Navigation
{
    public interface IPageResolver
    {
        Page GetPageWithAttachedViewModel(string viewName);
        Popup GetPopupPageWithAttachedViewModel(string popupName);
    }
}

