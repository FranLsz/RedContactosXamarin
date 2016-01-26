using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using DataModel.ViewModel;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;
using Xamarin.Forms;

namespace RedContactos.ViewModel
{
    public class MensajesRecibidosViewModel : GeneralViewModel
    {
        public ICommand CmdMensajesEnviados { get; set; }
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
                    _navigator.PushAsync<MensajeDetalleViewModel>(vm =>
                    {
                        var msj = value;
                        vm.Titulo = "Mensaje recibido nº " + value.Id;

                        vm.Mensaje = msj;
                    });
                    _mensajeSeleccionado = null;
                    SetProperty(ref value, null);
            }
        }

        public MensajesRecibidosViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
            CmdMensajesEnviados = new Command(MensajesEnviados);
        }

        private async void MensajesEnviados()
        {
            var list = await _servicio.GetMensajesEnviados(Session.User.Id);
            foreach (var l in list)
            {
                l.Emisor = await _servicio.GetUsuario(l.IdOrigen);
                l.Receptor = await _servicio.GetUsuario(l.IdDestino);
            }
            await _navigator.PushAsync<MensajesEnviadosViewModel>(
                o =>
                {
                    o.Titulo = "Mensajes enviados";
                    o.Mensajes = new ObservableCollection<MensajeModel>(list);
                });
        }
    }
}