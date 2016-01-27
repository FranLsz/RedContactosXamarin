using System;
using System.Windows.Input;
using DataModel.ViewModel;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;
using Xamarin.Forms;

namespace RedContactos.ViewModel
{
    public class MensajeDetalleViewModel : GeneralViewModel
    {
        public ICommand CmdBorrarMensaje { get; set; }
        public string BorrarMensajeLabel => "Eliminar mensaje";

        public MensajeModel Mensaje { get; set; }

        public MensajeDetalleViewModel(INavigator navigator, IServicioDatos servicio, Session session, IPage page) : base(navigator, servicio, session, page)
        {
            CmdBorrarMensaje = new Command(BorrarMensaje);
        }

        private async void BorrarMensaje()
        {
            await _servicio.DeleteMensaje(Mensaje.Id);
            await new Page().DisplayAlert("", "El mensaje ha sido eliminado", "Ok");
            await _navigator.PopAsync();
        }
    }
}