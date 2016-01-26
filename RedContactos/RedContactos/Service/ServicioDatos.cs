using System;
using System.Collections.Generic;
using System.Text;
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

        public async Task<UsuarioModel> GetUsuario(int id)
        {
            var request = new RestRequest("Usuario") { Method = Method.GET };
            request.AddQueryParameter("id", id);

            var response = await _client.Execute<UsuarioModel>(request);
            if (response.IsSuccess)
                return response.Data;

            return null;
        }

        #endregion


        #region Mensaje

        public async Task<ICollection<MensajeModel>> GetMensajesRecibidos(int userId)
        {
            var request = new RestRequest("Mensaje") { Method = Method.GET };
            request.AddQueryParameter("receptorId", userId);

            // la api devuelve error 404 si no existe, y restsharp peta
            var response = await _client.Execute<List<MensajeModel>>(request);
            if (response.IsSuccess)
                return response.Data;

            return null;
        }

        public async Task<ICollection<MensajeModel>> GetMensajesEnviados(int userId)
        {
            var request = new RestRequest("Mensaje") { Method = Method.GET };
            request.AddQueryParameter("emisorId", userId);

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
            var request = new RestRequest("Mensaje", Method.POST);
            request.AddJsonBody(model);
            //request.Parameters[0].ContentType = "application/json";
            //request.Parameters[0].Encoding = Encoding.UTF8;
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
            var request = new RestRequest("Mensaje") { Method = Method.DELETE };
            request.AddQueryParameter("id", id);

            await _client.Execute(request);
        }

        #endregion


        #region Contacto

        public async Task<ICollection<UsuarioModel>> GetContactos(int userId)
        {
            var request = new RestRequest("Contacto") { Method = Method.GET };
            request.AddQueryParameter("id", userId);

            var response = await _client.Execute<List<UsuarioModel>>(request);
            if (response.IsSuccess)
                return response.Data;

            return null;
        }

        public async Task<ContactoModel> AddContacto(ContactoModel model)
        {
            var request = new RestRequest("Contacto", Method.POST);
            request.AddJsonBody(model);
            var response = await _client.Execute<ContactoModel>(request);

            if (response.IsSuccess)
                return response.Data;
            return null;
        }

        public async Task DeleteContacto(int userId, int amigoId)
        {
            var request = new RestRequest("Contacto") { Method = Method.DELETE };
            request.AddQueryParameter("idUsuario", userId);
            request.AddQueryParameter("idAmigo", amigoId);

            await _client.Execute(request);
        }

        #endregion

    }
}