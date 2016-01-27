using MvvmLibrary.Factorias;
using MvvmLibrary.ViewModel.Base;
using RedContactos.Service;
using RedContactos.Util;

namespace RedContactos.ViewModel
{
    public class GeneralViewModel : ViewModelBase
    {
        protected INavigator _navigator;
        protected IServicioDatos _servicio;
        protected IPage _page;
        protected Session Session;

        public GeneralViewModel(INavigator navigator, IServicioDatos servicio, Session session, IPage page)
        {
            _navigator = navigator;
            _servicio = servicio;
            _page = page;
            Session = session;
        }
    }
}