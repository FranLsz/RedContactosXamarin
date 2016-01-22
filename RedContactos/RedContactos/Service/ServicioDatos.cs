using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataModel.ViewModel;
using RedContactos.Util;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;

namespace RedContactos.Service
{
    public class ServicioDatos : IServicioDatos
    {
        private readonly RestClient _client;

        public ServicioDatos()
        {
            _client = new RestClient(Cadenas.UrlServicio);
        }

        public async Task<UsuarioModel> ValidarUsuario(UsuarioModel model)
        {
            var request = new RestRequest("Usuario") { Method = Method.GET };
            request.AddQueryParameter("username", model.Username);
            request.AddQueryParameter("password", model.Password);

            
                var response = await _client.Execute<UsuarioModel>(request);
                if (response.IsSuccess)
                    return response.Data;
                return null;
          
        }

        public async Task<bool> UsuarioNuevo(string login)
        {
            var request = new RestRequest("Usuario") { Method = Method.GET };
            request.AddQueryParameter("username", login);

            var response = await _client.Execute<bool>(request);

            if (response.IsSuccess)
                return response.Data;
            return false;
        }

        public async Task<UsuarioModel> AddUsuario(UsuarioModel model)
        {
            var request = new RestRequest("Usuario")
            {
                Method = Method.POST
            };
            request.AddJsonBody(model);
            var response = await _client.Execute<UsuarioModel>(request);

            if (response.IsSuccess)
                return response.Data;
            return null;
        }

        public Task<ICollection<UsuarioModel>> GetUsuarios()
        {
            throw new System.NotImplementedException();
        }

        public Task<UsuarioModel> GetUsuario(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}