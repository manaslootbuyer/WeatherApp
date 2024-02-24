using System;
using Weather.Core.Base;
using Weather.Domain.Navigation;
using Weather.Domain.Navigation.Params;

namespace Weather.Core.DialogModels
{
    public class LoadingDialogModel : ViewModel, IInitializeAsync<string>, IInitializeAsync<ILoadingParam>, ILoading
    {

        public LoadingDialogModel()
        {
        }

        public async Task InitializeAsync(string param)
        {
            Message = param;
            await Task.Delay(1000);
        }

        public async Task InitializeAsync(ILoadingParam param)
        {
            Message = param.Message;
            await Task.Delay(1000);
        }

        private string _message = string.Empty;

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public void UpdateMessage(string message)
        {
            Message = message;
        }
    }
}

