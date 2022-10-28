using MiAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiAppMVC.Interfaces
{
    public interface IProductosRepo
    {
        public List<Productos> ListaProductos();
        public Productos Producto(int? id);

        public int Nuevo(Productos producto);
        public int Modificar(Productos producto);

        public int Eliminar(int? id);


    }
}
