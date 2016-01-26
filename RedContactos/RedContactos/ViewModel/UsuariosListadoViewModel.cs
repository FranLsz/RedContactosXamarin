using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Autofac.Features.ResolveAnything;
using DataModel.ViewModel;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;
using Xamarin.Forms;

namespace RedContactos.ViewModel
{
    public class UsuariosListadoViewModel : GeneralViewModel
    {

        public string ListadoUsuariosLabel { get { return "Usuarios disponibles"; } }

        private ObservableCollection<UsuarioModel> _listadoUsuarios;
        public ObservableCollection<UsuarioModel> ListadoUsuarios
        {
            get
            {
                return _listadoUsuarios;
            }

            set
            {
                SetProperty(ref _listadoUsuarios, value);
            }
        }

        private UsuarioModel _usuarioSeleccionado;
        public UsuarioModel UsuarioSeleccionado
        {
            get
            {
                return _usuarioSeleccionado;
            }

            set
            {
                
                AgregarContacto(value);
                _usuarioSeleccionado = null;
                SetProperty(ref value, null);

            }
        }

        public UsuariosListadoViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
            //UsuarioSeleccionado = new UsuarioModel();
        }

        public async void AgregarContacto(UsuarioModel model)
        {
            var cm = new ContactoModel
            {
                IdUsuario = Session.User.Id,
                IdAmigo = model.Id,
                Fecha = DateTime.Now
            };

            await _servicio.AddContacto(cm);
            await new Page().DisplayAlert(model.NombreCompleto, "Contacto agregado", "OK");

        }
    }
}