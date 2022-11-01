using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiAppMVC.Data;
using MiAppMVC.Models;
using MiAppMVC.Interfaces;

namespace MiAppMVC.Controllers
{
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly IProductosRepo _productosRepo;
       

        public ProductosController(IProductosRepo productosRepo)
        {
            _productosRepo = productosRepo ?? throw new ArgumentException(nameof(productosRepo)); 
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var lista = _productosRepo.ListaProductos();
            return View(lista);
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var detalle = _productosRepo.Producto(id);

            return View(detalle);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
       
        //[ValidateAntiForgeryToken]       
        [HttpPost]
        public async Task<IActionResult> Create([Bind("IdProductos,Nombre,Precio,IdCategoria,FechaAlta,FechaBaja,Estado,stock,modelo,proveedor,imagen")] Productos productos)
        {
            var productoNuevo = _productosRepo.Nuevo(productos);

            if (productoNuevo == 0)
            {
                //mostrar mensaje "no se pudo agregar el producto nuevo"
                //return view create
                //
            }

            List<Productos> lista = _productosRepo.ListaProductos();


            return RedirectToAction("index", "Productos");
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var productos = _productosRepo.Producto(id);
            
            return View(productos);
        }

        // POST: Productos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProductos,Nombre,Precio,IdCategoria,FechaAlta,FechaBaja,Estado")] Productos productos)
        {
            var productoModificado = _productosRepo.Modificar(productos);
          
            return View(productoModificado);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {

            var ProdEliminado = _productosRepo.Producto(id);

            return View(ProdEliminado);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ProdEliminado = _productosRepo.Eliminar(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ProductosExists(int id)
        {
            return _context.Productos.Any(e => e.IdProductos == id);
        }
    }
}
