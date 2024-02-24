using Weather.Domain.Navigation;

namespace Weather.Core.Base
{
    public abstract class ViewModel : NotifyPropertyChanged, IBusy
    {
        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
    }
}

