using MiAppMVC.Interfaces;
using MiAppMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MiAppMVC.Models;

namespace MiAppMVC.Repo
{
    public class ProductosRepo : IProductosRepo
    {
        private readonly ApplicationDbContext _context;
        //constructor
        public ProductosRepo(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));



        }

        public Productos Producto(int? id)
        {
            var producto = _context.Productos.FirstOrDefault(p => p.IdProductos == id);


            return producto;
        }

        public List<Productos> ListaProductos()
        {
            var lista = _context.Productos.Where(p => p.Estado == true).ToList();

            return lista;
        }
        /*List<Productos> IProductosRepo.ListaProductos { get => throw new NotImplementedException();*/
       
        public int Nuevo(Productos producto)
        {
            var existe = _context.Productos.Where(p => p.Nombre == producto.Nombre && p.proveedor == producto.proveedor);

            if (existe != null)
            {
                _context.Productos.Add(producto);

                

            }

            return _context.SaveChanges();
        }

        public int Modificar(Productos producto)
        {
            var objeto = _context.Productos.Where(p => p.IdProductos == producto.IdProductos).FirstOrDefault();

            if(objeto != null)

            {   objeto.IdProductos = producto.IdProductos;
                objeto.Nombre = producto.Nombre;
                objeto.Precio = producto.Precio;
                objeto.IdCategoria = producto.IdCategoria;
                objeto.FechaAlta = producto.FechaAlta;
                objeto.FechaBaja = producto.FechaBaja;
                objeto.Estado = producto.Estado;
                objeto.Descripcion = producto.Descripcion;
                objeto.idMarca = producto.idMarca;
                objeto.imagen = producto.imagen;
                objeto.modelo = producto.modelo;
                objeto.proveedor = producto.proveedor;
                objeto.stock = producto.stock;

                _context.Update(objeto);

            }

            return _context.SaveChanges();
        }

        public int Eliminar(int? id)
        {
            var objeto = _context.Productos.Where(p => p.IdProductos == id).FirstOrDefault();
            if (objeto != null)
            {
                objeto.Estado = false;
                objeto.FechaBaja = DateTime.Now;

                _context.Update(objeto);


            }

            return _context.SaveChanges();
        }

    }



}

