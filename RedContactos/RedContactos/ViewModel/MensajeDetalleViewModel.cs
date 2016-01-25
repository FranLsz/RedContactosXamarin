using DataModel.ViewModel;
using MvvmLibrary.Factorias;
using RedContactos.Service;
using RedContactos.Util;

namespace RedContactos.ViewModel
{
    public class MensajeDetalleViewModel : GeneralViewModel
    {
        public MensajeModel Mensaje { get; set; }

        public MensajeDetalleViewModel(INavigator navigator, IServicioDatos servicio, Session session) : base(navigator, servicio, session)
        {
        }
    }
}