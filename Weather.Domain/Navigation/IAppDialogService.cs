using System;
using Weather.Domain.Navigation.Params;

namespace Weather.Domain.Navigation
{
    public interface IAppDialogService
    {
        Task ShowLoading();
        Task ShowLoading(string message);
        Task HideLoading();
        Task ShowWarningAsync(string message);
        Task ShowWarningAsync(IMessageTitleParam param);
        Task ShowCustomWarningParam(string viewName, ICustomMessageParam param);
        Task ShowPopupPage<T>(string popupName, T param, bool isAnimated = true);
        Task ClosePopupPage();
        Task<bool> ShowConfirmAsync(IConfirmParam param);
    }
}

