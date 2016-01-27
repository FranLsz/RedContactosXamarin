using System.Windows.Input;
using DataModel.ViewModel;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;
using Xamarin.Forms;

namespace RedContactos.ViewModel
{
    public class DetalleUsuarioViewModel : GeneralViewModel
    {
        private UsuarioModel _usuario;
        public ICommand CmdAgregar;


        public DetalleUsuarioViewModel(INavigator navigator, IServicioDatos servicio, Session session, IPage page) : base(navigator, servicio, session, page)
        {
            _usuario = new UsuarioModel();
            CmdAgregar = new Command(AgregarContacto);
        }

        private void AgregarContacto()
        {
            throw new System.NotImplementedException();
        }

        public UsuarioModel Usuario
        {
            get
            {
                return _usuario;
            }

            set
            {
                _usuario = value;
            }
        }
    }
}