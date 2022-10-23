using MiAppMVC.CarritoDTO;
using MiAppMVC.Data;
using MiAppMVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiAppMVC.Repo
{
    public class UsuarioRepo : IUsuarioRepo
    {
        private readonly ApplicationDbContext _context;


        public UsuarioRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Logueo(Login obj)
        {
            bool existe = true;

            var _obj = _context.Usuarios.Where(p => p.usuario == obj.usuario && p.pass == obj.pass).FirstOrDefault();
            // select usuario, pass from Usuarios where usuario= hgoane and pass= 123456

            if (_obj == null)
            {
                existe = false;
            }

            return existe;
        }
    }
}
