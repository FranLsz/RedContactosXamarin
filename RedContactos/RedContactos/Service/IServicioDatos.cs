using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.ViewModel;

namespace RedContactos.Service
{
    public interface IServicioDatos
    {
        #region Usuario

        Task<UsuarioModel> ValidarUsuario(UsuarioModel model);
        Task<bool> CheckUsuario(string username);
        Task<UsuarioModel> AddUsuario(UsuarioModel model);
        Task<ICollection<UsuarioModel>> GetUsuarios();
        Task<UsuarioModel> GetUsuario(int id);

        #endregion


        #region Mensaje

        Task<List<MensajeModel>> GetMensajesRecibidos(int userId);
        Task<List<MensajeModel>> GetMensajesEnviados(int userId);
        Task<MensajeModel> GetMensaje(int id);
        Task<MensajeModel> AddMensaje(MensajeModel model);
        Task UpdateMensaje(MensajeModel model);
        Task DeleteMensaje(int id);

        #endregion

    }
}