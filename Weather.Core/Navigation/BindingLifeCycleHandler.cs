using System;
using System.Diagnostics.CodeAnalysis;
using Weather.Domain.Navigation;
using ISubscriber = Weather.Domain.Navigation.ISubscriber;

namespace Weather.Core.Navigation
{
    [ExcludeFromCodeCoverage]
    public class BindingLifeCycleHandler : IBindingLifeCycleHandler
    {
        public async Task InitializePageViewModel(BindableObject bindableObject)
        {
            if (bindableObject.BindingContext is IInitializeAsync initializeAsync)
            {
                await initializeAsync.InitializeAsync();
            }

            Subscribe(bindableObject);
        }


        public async Task InitializePageViewModel<T>(BindableObject bindableObject, T parameter)
        {
            if (bindableObject.BindingContext is IInitializeAsync<T> initializeAsync)
            {
                await initializeAsync.InitializeAsync(parameter);
            }
            else
            {
                throw new NotInitializableException($"{bindableObject.BindingContext?.GetType().Name} does not implement Initializable<{typeof(T).Name}>");
            }

            Subscribe(bindableObject);
        }

        private void Subscribe(BindableObject bindableObject)
        {
            if (bindableObject.BindingContext is ISubscriber subscriber)
            {
                subscriber.Subscribe();
            }
        }

        public void CleanUpPageViewModel(BindableObject bindableObject)
        {
            if (bindableObject.BindingContext is ISubscriber subscriber)
            {
                subscriber.Unsubscribe();
            }

            if (bindableObject.BindingContext is ICleanUp cleanUp)
            {
                cleanUp.CleanUp();
            }
        }

        public void NotifyPageWhenBackNavigated(BindableObject bindableObject)
        {
            if (bindableObject.BindingContext is IBackNavigationAware backNavigationAware)
            {
                backNavigationAware.OnNavigatedBack();
            }
        }
    }
}

