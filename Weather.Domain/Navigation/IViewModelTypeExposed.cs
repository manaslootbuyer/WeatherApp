using System;
namespace Weather.Domain.Navigation
{
    public interface IViewModelTypeExposed
    {
        Type ViewModelType { get; }
    }
}

