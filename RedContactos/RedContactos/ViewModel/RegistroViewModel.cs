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
    public class RegistroViewModel : GeneralViewModel
    {
        public ICommand cmdRegistro { get; set; }

        public string UsernameLabel { get { return "Username"; } }
        public string PasswordLabel { get { return "Password"; } }
        public string NombreLabel { get { return "Nombre"; } }
        public string ApellidosLabel { get { return "Apellidos"; } }

        public UsuarioModel Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        private UsuarioModel _usuario = new UsuarioModel();
        public RegistroViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
            cmdRegistro = new Command(GuardarUsuario);
        }

        private async void GuardarUsuario()
        {
            try
            {
                IsBusy = true;
                _usuario.Foto = "";
                var us = await _servicio.AddUsuario(_usuario);
                if (us != null)
                {
                    Session.User = us;
                    /*var list = new List<UsuarioModel>();
                      list.Remove(list.FirstOrDefault(o => o.Id == us.Id));
                      Session.ViewBag = list;*/
                    await _navigator.PushModalAsync<HomeViewModel>(o=>o.ListadoContactos = new List<UsuarioModel>());
                }
                else
                {
                    // Error al registrar
                }
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}