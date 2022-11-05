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
        public Cliente DetalleCliente(string nombre);
        public int Create(Cliente cliente);
        public int Modificar(Cliente cliente);
        public Cliente Cliente(int? id);


    }
}
