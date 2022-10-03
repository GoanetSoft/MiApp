using MiAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiAppMVC.Interfaces
{
    public interface IClienteRepo
    {
        public List<Cliente> InicioCliente();
        public Cliente DetalleCliente(int? id);

    }
}
