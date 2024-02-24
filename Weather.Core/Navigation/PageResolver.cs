using System;
using Autofac;
using Autofac.Core.Registration;
using System.Diagnostics.CodeAnalysis;
using Weather.Domain.Navigation;
using CommunityToolkit.Maui.Views;

namespace Weather.Core.Navigation
{
    [ExcludeFromCodeCoverage]
    public class PageResolver : IPageResolver
    {
        private readonly ILifetimeScope _scope;

        public PageResolver(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public Popup GetPopupPageWithAttachedViewModel(string popupName)
        {
            try
            {
                var page = _scope.ResolveNamed<Popup>(popupName);

                if (page is IViewModelTypeExposed viewModelTypeExposed)
                {
                    page.BindingContext = _scope.Resolve(viewModelTypeExposed.ViewModelType);
                }

                return page;
            }
            catch (ComponentNotRegisteredException ex)
            {
                throw new PageNotYetImplementedException($"Page named {popupName} is not yet implemented.", ex);
            }
        }

        public Page GetPageWithAttachedViewModel(string viewName)
        {
            try
            {
                var page = _scope.ResolveNamed<Page>(viewName);

                if (page is IViewModelTypeExposed viewModelTypeExposed)
                {
                    page.BindingContext = _scope.Resolve(viewModelTypeExposed.ViewModelType);
                }

                return page;
            }
            catch (ComponentNotRegisteredException ex)
            {
                throw new PageNotYetImplementedException($"Page named {viewName} is not yet implemented.", ex);
            }
        }

    }
}
