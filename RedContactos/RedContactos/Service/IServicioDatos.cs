using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.ViewModel;

namespace RedContactos.Service
{
    public interface IServicioDatos
    {
        Task<UsuarioModel> ValidarUsuario(UsuarioModel model);

        Task<bool> UsuarioNuevo(string login);

        Task<UsuarioModel> AddUsuario(UsuarioModel model);

        Task<ICollection<UsuarioModel>> GetUsuarios();

        Task<UsuarioModel> GetUsuario(string id);
    }
}