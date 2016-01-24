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

        Task<UsuarioModel> GetUsuario(string id);

        #endregion

    }
}