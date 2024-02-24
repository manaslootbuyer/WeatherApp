using System;
namespace Weather.Domain.Navigation
{
    public interface ISubscriber
    {
        void Subscribe();

        void Unsubscribe();
    }
}

