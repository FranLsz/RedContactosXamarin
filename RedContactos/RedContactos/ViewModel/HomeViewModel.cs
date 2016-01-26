using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

        private ObservableCollection<UsuarioModel> _listadoContactos;
        public ObservableCollection<UsuarioModel> ListadoContactos
        {
            get
            {
                return _listadoContactos;
            }
            set { SetProperty(ref _listadoContactos, value); }
        }

        public UsuarioModel ContactoSeleccionado
        {
            get { return _contactoSeleccionado; }
            set
            {
                _navigator.PushAsync<UsuarioDetalleViewModel>(vm =>
                {
                    vm.Titulo = value.Username;
                    vm.Usuario = value;
                });
                _contactoSeleccionado = null;
                SetProperty(ref value, null);
            }
        }

        public UsuarioModel _contactoSeleccionado;

        public HomeViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
            cmdNuevoContacto = new Command(NuevoContacto);
            cmdMisMensajes = new Command(MisMensajes);
        }



        private async void NuevoContacto()
        {
            var list = await _servicio.GetUsuarios();
            var contactos = await _servicio.GetContactos(Session.User.Id);
            var finalList = new List<UsuarioModel>(list);

            foreach (var l in from l in list from c in contactos.Where(c => c.Id == l.Id || l.Id == Session.User.Id) select l)
            {
                finalList.Remove(l);
            }

            await _navigator.PushAsync<UsuariosListadoViewModel>(o => o.ListadoUsuarios = new ObservableCollection<UsuarioModel>(finalList));
        }

        private async void MisMensajes()
        {
            var list = await _servicio.GetMensajesRecibidos(Session.User.Id);
            foreach (var l in list)
            {
                l.Emisor = await _servicio.GetUsuario(l.IdOrigen);
                l.Receptor = await _servicio.GetUsuario(l.IdDestino);
            }
            await _navigator.PushAsync<MensajesRecibidosViewModel>(
                   o =>
                   {
                       o.Titulo = "Mensajes recibidos";
                       o.Mensajes = new ObservableCollection<MensajeModel>(list);
                   });
        }
    }
}