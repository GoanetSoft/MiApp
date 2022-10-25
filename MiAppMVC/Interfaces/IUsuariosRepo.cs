﻿using MiAppMVC.CarritoDTO;
using MiAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiAppMVC.Interfaces
{
    public interface IUsuariosRepo
    {
        public bool Logueo(Login obj);

        public int Create(Usuarios usuarios);

        public int Edit(Usuarios usuarios);
        public Usuarios Usuario(int? id);

        public List<Usuarios> ListadoUsuarios();
    }
}
