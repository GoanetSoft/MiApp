﻿using System;
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
    public class ClienteController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IClienteRepo _clienteRepo;

        
        public ClienteController(IClienteRepo clienteRepo)
        {
            _clienteRepo = clienteRepo ?? throw new ArgumentException(nameof(clienteRepo));
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            var listaCliente = _clienteRepo.InicioCliente();
      

            return View(listaCliente);
        }

        public async Task<IActionResult> Details(string dni)
        {

            var cliente = _clienteRepo.DetalleCliente(dni);

            if (cliente == null)
            {

                //una vista con un texbox y un boton 
                // devuelven mensaje
            }
            else
            {
                cliente = _clienteRepo.DetalleCliente(cliente.IdCliente);
            }

            return View(cliente);
        }
        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var cliente = _clienteRepo.DetalleCliente(id);

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,Nombre,RazonSocial,Documento,Estado")] Cliente cliente)
        {
           

            int resultado = 0;

            if (ModelState.IsValid)
            {
                resultado = _clienteRepo.Create(cliente);

            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)

        {
            
            var cliente = _clienteRepo.Cliente(id);

            return View(cliente);

           
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,Nombre,RazonSocial,Documento,Estado")] Cliente cliente)
        {
            var clienteModificado = _clienteRepo.Modificar(cliente);

            return View(cliente);
        }
    

        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Cliente
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.IdCliente == id);
        }
    }
}
