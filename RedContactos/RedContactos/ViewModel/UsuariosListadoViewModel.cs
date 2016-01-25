using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                new Page().DisplayAlert("Agregar contacto...", value.NombreCompleto, "OK");
                _usuarioSeleccionado = value;
            }
        }

        public UsuariosListadoViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
            //UsuarioSeleccionado = new UsuarioModel();
        }
    }
}