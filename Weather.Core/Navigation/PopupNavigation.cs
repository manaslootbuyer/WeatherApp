using System;
using CommunityToolkit.Maui.Views;

namespace Weather.Core.Navigation
{
    public class PopupNavigation : IPopupNavigation
    {
        private readonly NavigationPage _navigationPage;
        private readonly List<Popup> _popupStack;

        public PopupNavigation(NavigationPage navigationPage)
        {
            _navigationPage = navigationPage;
            _popupStack = new List<Popup>();
        }

        public IEnumerable<Popup> PopupStack => _popupStack;

        public void ShowPopup(Popup popup)
        {
            if (_popupStack.Contains(popup))
            {
                _popupStack.Remove(popup);
            }

            _popupStack.Add(popup);

            _navigationPage.ShowPopup(popup);
        }

        public async Task ShowPopupAsync(Popup popup)
        {
            if (_popupStack.Contains(popup))
            {
                _popupStack.Remove(popup);
            }
            _popupStack.Add(popup);

            await _navigationPage.ShowPopupAsync(popup);
        }

        public void ClosePopup(Popup popup)
        {
            if (_popupStack.Contains(popup))
            {
                _popupStack.Remove(popup);
            }

            popup.Close();
        }
    }
}

