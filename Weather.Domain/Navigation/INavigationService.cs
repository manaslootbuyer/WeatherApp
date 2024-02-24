using System;
namespace Weather.Domain.Navigation
{
    public interface INavigationService
    {
        Task PushAsync(string viewName);
        Task PushAsync<T>(string viewName, T parameter);
        Task PushToNewRootPage(string viewName);
        Task PushToNewRootPage<T>(string viewName, T parameter);
        Task PopAsync();
    }
}

