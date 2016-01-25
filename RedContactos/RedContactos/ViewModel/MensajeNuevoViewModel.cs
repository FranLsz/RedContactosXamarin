using System;
using System.Windows.Input;
using DataModel.ViewModel;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;
using Xamarin.Forms;

namespace RedContactos.ViewModel
{
    public class MensajeNuevoViewModel : GeneralViewModel
    {
        public ICommand CmdEnviar { get; set; }
        public string AsuntoLabel => "Asunto";
        public string ContenidoLabel => "Contenido";
        public string EnviarLabel => "Enviar";

        public UsuarioModel Emisor { get; set; }
        public UsuarioModel Receptor { get; set; }

        private MensajeModel _mensaje;
        public MensajeModel Mensaje
        {
            get { return _mensaje; }
            set { SetProperty(ref _mensaje, value); }
        }

        public MensajeNuevoViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
            _mensaje = new MensajeModel();
            CmdEnviar = new Command(Enviar);
        }

        private async void Enviar()
        {
            Mensaje.IdOrigen = Emisor.Id;
            Mensaje.IdDestino = Receptor.Id;
            Mensaje.Fecha = DateTime.Now;
            Mensaje.Leido = false;
            try
            {
                var res = await _servicio.AddMensaje(Mensaje);
                if (res != null)
                {
                    await new Page().DisplayAlert("", "Mensaje enviado", "Ok");
                    await _navigator.PopAsync();
                }
                else
                {
                    await new Page().DisplayAlert("Error", "Mensaje no enviado", "Ok");
                }
            }
            catch (Exception ex)
            {
                await new Page().DisplayAlert("Error", ex.Message, "Ok");
            }
        }
    }
}