using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ICommand cmdHazAlgo { get; set; }


        public string NuevoContactoLabel { get { return "Nuevo contacto"; } }
        public string MisMensajesLabel { get { return "Mis mensajes"; } }
        public string MisContactosLabel { get { return "Mis contactos"; } }

        private ObservableCollection<UsuarioModel> _listadoContactos;
        public ObservableCollection<UsuarioModel> ListadoContactos
        {
            get
            {
                return _listadoContactos;
            }
            set { SetProperty(ref _listadoContactos, value); }
        }


        public HomeViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
            cmdNuevoContacto = new Command(NuevoContacto);
            cmdMisMensajes = new Command(MisMensajes);
            cmdHazAlgo = new Command(HazAlgo);
        }

        private void HazAlgo(object obj)
        {
            var hemosllegado = obj;
        }

        private async void NuevoContacto()
        {
            var list = await _servicio.GetUsuarios();
            list.Remove(list.FirstOrDefault(o => o.Id == Session.User.Id));

            await _navigator.PushAsync<UsuariosViewModel>(o => o.ListadoUsuarios = new ObservableCollection<UsuarioModel>(list));
        }

        private void MisMensajes()
        {

        }
    }
}