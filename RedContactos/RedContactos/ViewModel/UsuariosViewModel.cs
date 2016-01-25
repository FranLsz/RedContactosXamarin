using System.Collections.Generic;
using System.Collections.ObjectModel;
using DataModel.ViewModel;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;
using Xamarin.Forms;

namespace RedContactos.ViewModel
{
    public class UsuariosViewModel : GeneralViewModel
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
                new Page().DisplayAlert("Item pulsado", value.NombreCompleto, "OK");
                _usuarioSeleccionado = value;
            }
        }

        public UsuariosViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
            //UsuarioSeleccionado = new UsuarioModel();
        }
    }
}