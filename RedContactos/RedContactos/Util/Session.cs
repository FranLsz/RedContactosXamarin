using System;
using System.Collections.Generic;
using DataModel.ViewModel;

namespace RedContactos.Util
{
    public class Session
    {
        public  UsuarioModel User { get; set; }

        private Dictionary<string, object> _session = new Dictionary<string, object>();

        public Object this[string index]
        {
            get { return _session[index]; }
            set { _session[index] = value; }
        }
    }
}