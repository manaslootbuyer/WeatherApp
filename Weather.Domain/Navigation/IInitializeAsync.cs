namespace Weather.Domain.Navigation
{
    public interface IInitializeAsync
    {
        Task InitializeAsync();
    }

    public interface IInitializeAsync<in T>
    {
        Task InitializeAsync(T param);
    }
}

