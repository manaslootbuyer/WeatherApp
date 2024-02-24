namespace Weather.Domain.Navigation
{
    public interface IBackNavigationAware
    {
        Task OnNavigatedBack();
    }
}

