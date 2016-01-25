using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DataModel.ViewModel;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;
using RedContactos.View;
using Xamarin.Forms;

namespace RedContactos.ViewModel
{
    public class LoginViewModel : GeneralViewModel
    {
        // COMMANDS
        public ICommand cmdLogin { get; set; }
        public ICommand cmdRegistro { get; set; }

        // PROPERTIES
        public string IniciarLabel { get { return "Iniciar sesión"; } }
        public string RegistroLabel { get { return "Registro"; } }
        public string TituloUsername { get { return "Nombre de usuario"; } }
        public string TituloPassword { get { return "Contraseña"; } }

        private UsuarioModel _usuario;
        public UsuarioModel Usuario
        {
            get { return _usuario; }
            set { SetProperty(ref _usuario, value); }
        }

        // PAGE
        public Page Page;

        // CTOR
        public LoginViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
            Page = new Page();
            Usuario = new UsuarioModel();
            Usuario = new UsuarioModel();
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
                    Session.User= us;
                    var list = await _servicio.GetUsuarios();
                    //var list = new List<UsuarioModel>();
                    await _navigator.PushAsync<HomeViewModel>(o => o.ListadoContactos = new ObservableCollection<UsuarioModel>(list));
                }
                else
                {
                    await Page.DisplayAlert("Imposible iniciar sesión", "El usuario o contraseña son incorrectos", "OK");
                }
            }
            catch (Exception e)
            {
                await Page.DisplayAlert("Error", e.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }


    }
}