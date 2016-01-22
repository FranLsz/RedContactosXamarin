using System;
using System.Collections.Generic;
using System.Windows.Input;
using DataModel.ViewModel;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;
using Xamarin.Forms;

namespace RedContactos.ViewModel
{
    public class LoginViewModel : GeneralViewModel
    {
        public ICommand cmdLogin { get; set; }
        public ICommand cmdRegistro { get; set; }

        public string IniciarLabel { get { return "Iniciar sesión"; } }
        public string RegistroLabel { get { return "Registro"; } }
        public string TituloUsername { get { return "Nombre de usuario"; } }
        public string TituloPassword { get { return "Contraseña"; } }

        private UsuarioModel _usuario = new UsuarioModel();
        public UsuarioModel Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        public LoginViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
            cmdLogin = new Command(IniciarSesion);
            cmdRegistro = new Command(NuevoUsuario);
        }

        private async void NuevoUsuario()
        {
            await _navigator.PushAsync<RegistroViewModel>();
        }


        private async void IniciarSesion()
        {
            try
            {
                IsBusy = true;
                var us = await _servicio.ValidarUsuario(_usuario);
                if (us != null)
                {
                    Session.User = us;
                    var list = new List<UsuarioModel>();
                    await _navigator.PushAsync<HomeViewModel>(o => o.ListadoContactos = list);
                }
                else
                {
                    // Usuario no encontrado
                }
            }
            catch (Exception ex)
            {
                var ee = ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}