using System;
namespace Weather.Domain.Navigation.Params
{
    public interface IConfirmParam : IMessageTitleParam
    {
        event EventHandler<bool> ConfirmationCompleted;
    }
}

