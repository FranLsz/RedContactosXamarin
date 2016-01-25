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
        protected Session Session;

        public GeneralViewModel(INavigator navigator, IServicioDatos servicio, Session session)
        {
            _navigator = navigator;
            _servicio = servicio;
            Session = session;
        }
    }
}