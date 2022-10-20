using MiAppMVC.CarritoDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiAppMVC.Interfaces
{
    public interface IUsuarioRepo
    {
        public bool Logueo(Login obj);
    }
}
