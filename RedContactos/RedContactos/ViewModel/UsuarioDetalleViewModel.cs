using System.Collections.ObjectModel;
using System.Windows.Input;
using DataModel.ViewModel;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;
using Xamarin.Forms;

namespace RedContactos.ViewModel
{
    public class UsuarioDetalleViewModel : GeneralViewModel
    {
        public ICommand CmdEnviarMensaje { get; set; }
        public ICommand CmdBorrarContacto { get; set; }
        public string EnviarMensajeLabel { get { return "Enviar mensaje"; } }
        public string BorrarContactoLabel { get { return "Eliminar contacto"; } }

        public UsuarioModel Usuario { get; set; }

        public UsuarioDetalleViewModel(INavigator navigator, IServicioDatos servicio, Session session, IPage page) : base(navigator, servicio, session, page)
        {
            CmdEnviarMensaje = new Command(EnviarMensaje);
            CmdBorrarContacto = new Command(BorrarContacto);
        }

        private async void BorrarContacto()
        {
            await _servicio.DeleteContacto(Session.User.Id, Usuario.Id);
            await new Page().DisplayAlert("", "Contacto eliminado", "Ok");

            var list = await _servicio.GetContactos(Session.User.Id);
            await _navigator.PushAsync<HomeViewModel>(o =>
            {
                o.Titulo = "Bienvenido " + Session.User.Username;
                o.ListadoContactos = new ObservableCollection<UsuarioModel>(list);
            }
            );
        }

        private async void EnviarMensaje()
        {
            await _navigator.PushAsync<MensajeNuevoViewModel>(vm =>
            {
                vm.Titulo = "Mensaje para " + Usuario.Username;
                vm.Emisor = Session.User;
                vm.Receptor = Usuario;
            });
        }
    }
}