using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using PropertyChangingEventArgs = System.ComponentModel.PropertyChangingEventArgs;
using PropertyChangingEventHandler = System.ComponentModel.PropertyChangingEventHandler;

namespace Weather.Core.Base
{
    public class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public event PropertyChangingEventHandler? PropertyChanging;

        protected void SetProperty<T>(ref T backingStore, T value, Action? onChanged = null, Action<T>? onChanging = null, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return;
            }

            onChanging?.Invoke(value);

            OnPropertyChanging(value, propertyName);

            backingStore = value;

            onChanged?.Invoke();

            OnPropertyChanged(propertyName);
        }

        protected void OnPropertyChanging<T>(T newValue, [CallerMemberName] string? propertyName = null)
        {
            PropertyIsChanging(propertyName, newValue);
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyHasChanged(propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void PropertyHasChanged(string? propertyName)
        {

        }

        protected virtual void PropertyIsChanging(string? propertyName, object? newValue)
        {

        }
    }
}