using CommunityToolkit.Mvvm.Input;
using Weather.Core.Base;
using Weather.Domain.Navigation;
using Weather.Domain.Navigation.Params;

namespace Weather.Core.DialogModels
{
    public class AlertDialogModel : ViewModel,
       IInitializeAsync<string>,
       IInitializeAsync<IMessageTitleParam>
    {
        private readonly IAppDialogService _appDialogService;

        public AlertDialogModel(IAppDialogService appDialogService)
        {
            _appDialogService = appDialogService;
            CloseCommand = new RelayCommand(Close);
        }

        public Task InitializeAsync(string param)
        {
            Message = param;
            Title = string.Empty;
            // CloseText = AppResources.Label_Close;
            return Task.CompletedTask;
        }

        public Task InitializeAsync(IMessageTitleParam param)
        {
            Message = param.Message;
            Title = param.Title;
            // CloseText = AppResources.Label_Close;
            return Task.CompletedTask;
        }

        public IRelayCommand CloseCommand { get; }

        private bool _isInfo = true;
        public bool IsInfo
        {
            get => _isInfo;
            set => SetProperty(ref _isInfo, value);
        }

        private string _title = string.Empty;

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        private string _message = string.Empty;

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        private string _closeText = string.Empty;

        public string CloseText
        {
            get => _closeText;
            set => SetProperty(ref _closeText, value);
        }

        private void Close()
        {
            _appDialogService.ClosePopupPage();
        }
    }
}

