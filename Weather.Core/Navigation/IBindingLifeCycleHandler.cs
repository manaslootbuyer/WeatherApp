using System;
namespace Weather.Core.Navigation
{
    public interface IBindingLifeCycleHandler
    {
        Task InitializePageViewModel(BindableObject bindableObject);
        Task InitializePageViewModel<T>(BindableObject bindableObject, T parameter);
        void CleanUpPageViewModel(BindableObject bindableObject);
        void NotifyPageWhenBackNavigated(BindableObject bindableObject);
    }
}

