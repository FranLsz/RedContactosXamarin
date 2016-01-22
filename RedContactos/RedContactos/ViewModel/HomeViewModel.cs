using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using DataModel.ViewModel;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;
using Xamarin.Forms;

namespace RedContactos.ViewModel
{
    public class HomeViewModel : GeneralViewModel
    {
        public ICommand cmdNuevoContacto { get; set; }
        public ICommand cmdMisMensajes { get; set; }

        public string NuevoContactoLabel { get { return "Nuevo contacto"; } }
        public string MisMensajesLabel { get { return "Mis mensajes"; } }
        public string MisContactosLabel { get { return "Mis contactos"; } }

        public ICollection<UsuarioModel> ListadoContactos { get; set; }

        public HomeViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
            cmdNuevoContacto = new Command(NuevoContacto);
            cmdMisMensajes = new Command(MisMensajes);
        }

        private async void NuevoContacto()
        {
            var list = await _servicio.GetUsuarios();
            list.Remove(list.FirstOrDefault(o => o.Id == Session.User.Id));

            await _navigator.PushAsync<UsuariosViewModel>(o => o.ListadoUsuarios = list);
        }

        private void MisMensajes()
        {

        }
    }
}