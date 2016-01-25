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
        public string EnviarMensajeLabel { get { return "Enviar mensaje"; } }

        public UsuarioModel Usuario { get; set; }

        public UsuarioDetalleViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
            CmdEnviarMensaje = new Command(EnviarMensaje);
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