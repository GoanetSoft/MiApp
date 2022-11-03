using MiAppMVC.CarritoDTO;
using MiAppMVC.Data;
using MiAppMVC.Interfaces;
using MiAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiAppMVC.Repo
{
    public class UsuariosRepo : IUsuariosRepo
    {
        private readonly ApplicationDbContext _context;

       
        public UsuariosRepo(ApplicationDbContext context)
        {
            _context = context;
        }

        public int Create(Usuarios usuarios)
        {
            usuarios.fechaAlta = DateTime.Now;
            usuarios.estado = true;

            _context.Add(usuarios);

            var resultado =  _context.SaveChanges();

            return resultado;
           
        }

        public int Edit(Usuarios usuarios)
        {
            var objeto = _context.Usuarios.Where(u => u.idUsuario == usuarios.idUsuario).FirstOrDefault();

            objeto.usuario = usuarios.usuario;
            objeto.pass = usuarios.pass;

            _context.Update(objeto);

            var resultado = _context.SaveChanges();

            return resultado;
        }

        public Usuarios Usuario(int? id)
        {
            var usuario = _context.Usuarios.Where(u => u.idUsuario == id).FirstOrDefault();
            
            return usuario;
        }

        public List<Usuarios> ListadoUsuarios()
        {
            var usuario = _context.Usuarios.ToList();

            return usuario;
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

        public Usuarios Detalle(int? id)
        {
            var obj = _context.Usuarios.Where(u => u.idUsuario == id).FirstOrDefault();


            return obj;
        }

    }

   
}
