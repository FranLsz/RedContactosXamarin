using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModel.ViewModel;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;

namespace RedContactos.ViewModel
{
    public class MensajesEnviadosViewModel : GeneralViewModel
    {
        public string MensajesRecibidosLabel => "Bandeja de entrada";
        public string MensajesEnviadosLabel => "Ver mensajes enviados";

        private ObservableCollection<MensajeModel> _mensajes;
        public ObservableCollection<MensajeModel> Mensajes
        {
            get { return _mensajes; }
            set { SetProperty(ref _mensajes, value); }
        }

        private MensajeModel _mensajeSeleccionado;
        public MensajeModel MensajeSeleccionado
        {
            get { return _mensajeSeleccionado; }
            set
            {
                if (value != null)
                {
                    _mensajeSeleccionado = value;
                    _navigator.PushAsync<MensajeDetalleViewModel>(vm =>
                    {
                        vm.Titulo = "Mensaje enviado nº " + value.Id;
                        vm.Mensaje = value;
                    });
                    _mensajeSeleccionado = null;
                    SetProperty(ref value, null);
                }

            }
        }
        public MensajesEnviadosViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
        }
    }
}
