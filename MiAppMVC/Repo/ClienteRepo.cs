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
            var client = _context.Cliente.FirstOrDefault(m => m.IdCliente == id);  // Select * from Cliente where idCliente= id

            return cliente;
        }
    }
}
