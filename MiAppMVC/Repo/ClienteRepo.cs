using MiAppMVC.Data;
using MiAppMVC.Interfaces;
using MiAppMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiAppMVC.Repo
{
    public class ClienteRepo : IClienteRepo
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepo(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }
        public Cliente Cliente(int? id)

        {
            var cliente = _context.Cliente.FirstOrDefault(p => p.IdCliente == id);


            return cliente;
        }
        public List<Cliente> InicioCliente()
        {
            var listaCliente = _context.Cliente.ToList(); // select * from Cliente
            var listCliente = _context.Cliente.ToList(); // select * from Cliente

            ///CONECTARA A LA BASE DE DATOS
            ///ABRIR LA BASE DE DATOS
            ///HACER UN SELECT * FROM CLIENTES
            ///RETORNE ESE SELECT Y GUARDARLO EN UN DATASET
            ///ESE DATASATE PASARLO A UN DATAGRID 
            ///ME MUESTRE EN LA GRILLA DEL FRONT
            ///CIERRO BASE DE DATOS

            return listaCliente;
        }

        public Cliente DetalleCliente(int? id)
        {

            var cliente = _context.Cliente.FirstOrDefault(m => m.IdCliente == id);  // Select * from Cliente where idCliente= id
            

            return cliente;
        }

        public Cliente DetalleCliente(string dni)
        {

            var cliente = _context.Cliente.FirstOrDefault(m => m.Documento == dni );  // Select * from Cliente where idCliente= id


            return cliente;
        }

        public int Create(Cliente cliente)
        {
           

            cliente.Estado = true;

            _context.Add(cliente);

            var resultado = _context.SaveChanges();
            return resultado;
                
        }

        public int Modificar(Cliente cliente)
        {
            var objeto = _context.Cliente.Where(c => c.IdCliente == cliente.IdCliente).FirstOrDefault();

            if (objeto != null)
            {
                objeto.IdCliente = cliente.IdCliente;
                objeto.Nombre = cliente.Nombre;
                objeto.RazonSocial = cliente.RazonSocial;
                objeto.Documento = cliente.Documento;
            }

            return _context.SaveChanges();
        }
    }
}
