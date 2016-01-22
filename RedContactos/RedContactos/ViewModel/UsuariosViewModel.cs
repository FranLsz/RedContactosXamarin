﻿using System.Collections.Generic;
using DataModel.ViewModel;
using MvvmLibrary.Factorias;
using RedContactos.Service;

namespace RedContactos.ViewModel
{
    public class UsuariosViewModel : GeneralViewModel
    {

        public ICollection<UsuarioModel> ListadoUsuarios { get; set; }
        public string ListadoUsuariosLabel { get { return "Usuarios disponibles"; } }

        public UsuariosViewModel(INavigator navigator, IServicioDatos servicio) : base(navigator, servicio)
        {
        }
    }
}