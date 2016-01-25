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

        #region Usuario

        public async Task<UsuarioModel> ValidarUsuario(UsuarioModel model)
        {
            var request = new RestRequest("Usuario") { Method = Method.GET };
            request.AddQueryParameter("username", model.Username);
            request.AddQueryParameter("password", model.Password);

            // la api devuelve error 404 si no existe, y restsharp peta
            var response = await _client.Execute<UsuarioModel>(request);
            if (response.IsSuccess)
                return response.Data;

            return null;

        }

        public async Task<bool> CheckUsuario(string username)
        {
            var request = new RestRequest("Usuario") { Method = Method.GET };
            request.AddQueryParameter("username", username);

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

        public async Task<ICollection<UsuarioModel>> GetUsuarios()
        {
            var request = new RestRequest("Usuario") { Method = Method.GET };

            var response = await _client.Execute<ICollection<UsuarioModel>>(request);
            if (response.IsSuccess)
                return response.Data;
            return null;
        }

        public Task<UsuarioModel> GetUsuario(string id)
        {
            throw new NotImplementedException();
        }

        #endregion


        #region Mensaje

        public async Task<List<MensajeModel>> GetMensajes(int userId)
        {
            var request = new RestRequest("Mensaje") { Method = Method.GET };
            request.AddQueryParameter("destino", userId);

            // la api devuelve error 404 si no existe, y restsharp peta
            var response = await _client.Execute<List<MensajeModel>>(request);
            if (response.IsSuccess)
                return response.Data;

            return null;
        }

        public async Task<MensajeModel> GetMensaje(int id)
        {
            var request = new RestRequest("Mensaje") { Method = Method.GET };
            request.AddQueryParameter("id", id);

            // la api devuelve error 404 si no existe, y restsharp peta
            var response = await _client.Execute<MensajeModel>(request);
            if (response.IsSuccess)
                return response.Data;

            return null;
        }

        public async Task<MensajeModel> AddMensaje(MensajeModel model)
        {
            var request = new RestRequest("Mensaje")
            {
                Method = Method.POST
            };
            request.AddJsonBody(model);
            var response = await _client.Execute<MensajeModel>(request);

            if (response.IsSuccess)
                return response.Data;
            return null;
        }

        public async Task UpdateMensaje(MensajeModel model)
        {
            var request = new RestRequest("Mensaje") { Method = Method.PUT };
            request.AddJsonBody(model);

            await _client.Execute(request);
        }

        public async Task DeleteMensaje(int id)
        {
            var request = new RestRequest("Mensaje") { Method = Method.POST };
            request.AddQueryParameter("id", id);

            await _client.Execute(request);
        }

        #endregion

    }
}