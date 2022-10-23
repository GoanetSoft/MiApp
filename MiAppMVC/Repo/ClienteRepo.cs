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
            _context = context;
        }

        public List<Cliente> InicioCliente()
        {
            var listaCliente = _context.Cliente.ToList(); // select * from Cliente
            

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

            var cliente = _context.Cliente.FirstOrDefault(m => m.IdCliente == id);  
                         //base de datos = _context
                         //Cliente es la tabla de mi bd
                         //firstOrDefault es un metodo quie trae el primer elemnto que encontro
                         //m = a la tabla
                         //m.Idcliente es el campo de mi tabla   //
                         //Select * from Cliente where idCliente= id
            

            return cliente;
        }

        public Cliente CrearCliente(Cliente cliente)
        {
            var obj = _context.Cliente.FirstOrDefault(m => m.Documento == cliente.Documento );

            if (obj == null) //verifico que el CLIENTE que voy a dar de alta NO EXISTE
            {
                cliente.Estado = true; // asigno estado del cliente con true para decir que esta activo
                
                _context.Add(cliente);
                _context.SaveChanges();
                obj = cliente;

                return obj;
            }

            return cliente;            
        }

        public List<Cliente> InicioClientes()
        {
            throw new NotImplementedException();
        }
    }
}
