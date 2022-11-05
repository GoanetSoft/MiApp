using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MiAppMVC.Data;
using MiAppMVC.Models;
using MiAppMVC.CarritoDTO;
using MiAppMVC.Interfaces;
using System.Web;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MiAppMVC.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IUsuariosRepo _usuariosRepo;

        public UsuariosController(IUsuariosRepo usuario)
        {
            _usuariosRepo = usuario ?? throw new ArgumentException(nameof(usuario));
           

        }
       
        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            return View(_usuariosRepo.ListadoUsuarios());
        }

        // GET: Usuarios/Details/5
       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuarios = _usuariosRepo.Detalle(id);

            if (usuarios == null)
            {

                //var msj = "usuario no encontrado";
                //string script = string.Format("alert('Bienvenido:{0}');", msj);

                ////ClientScriptManager; 
                //return Content(script);
            }

            return View(usuarios);
        }

        private string mensaje(string texto)
        {
            
            string script = string.Format("alert('Bienvenido:{0}');", texto);
           

            return script;

        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Login()
        {

            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("idUsuario,usuario,pass,estado,fechaAlta")] Usuarios usuarios)
        {
            int resultado = 0;

            if (ModelState.IsValid)
            {
                resultado = _usuariosRepo.Create(usuarios);
            }
            
            return View(usuarios);
        }


        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {         
                return NotFound();
            }

            var usuarios = _usuariosRepo.Usuario(id);
            if (usuarios == null)
            {
                return NotFound();
            }
            return View(usuarios);

        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("idUsuario,usuario,pass,estado,fechaAlta")] Usuarios usuarios)
        {
            var resultado = 0;
            if (ModelState.IsValid)
            {
                resultado = _usuariosRepo.Edit(usuarios);
            }

            return View(usuarios);
           
        }
        [HttpPost]
        public async Task<IActionResult> Logueo([Bind("usuario,pass")] Login obj)
        {
            var _logueo = _usuariosRepo.Logueo(obj);

            if (_logueo)
            {
                return View("Views/Productos/Indexlogueado.cshtml");
            }
            else
            {
                return View();
            }
          
        }
       
            public async Task<IActionResult> Delete(int? id)

             {

            var UsuarioEliminado = _usuariosRepo.Usuario(id);
            return View(UsuarioEliminado);
            
             }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var UsuarioEliminado = _usuariosRepo.Eliminar(id);

            return RedirectToAction(nameof(Index));
        }

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.idUsuario == id);            
        
        }
    }
}
