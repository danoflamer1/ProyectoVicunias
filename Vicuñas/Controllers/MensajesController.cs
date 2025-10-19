using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Micontexto.Context;
using Vicuñas.Models;

namespace Vicuñas.Controllers
{
    public class MensajesController : Controller
    {
        private readonly ContextoV _context;

        public MensajesController(ContextoV context)
        {
            _context = context;
        }

        // GET: Mensajes
        public async Task<IActionResult> Index()
        {
            var contextoV = _context.Mensaje.Include(m => m.Estudiante).Include(m => m.Usuario);
            return View(await contextoV.ToListAsync());
        }

        // GET: Mensajes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensaje = await _context.Mensaje
                .Include(m => m.Estudiante)
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mensaje == null)
            {
                return NotFound();
            }

            return View(mensaje);
        }

        // GET: Mensajes/Create
        public IActionResult Create()
        {
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Apellido_M");
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Apellido_M");
            return View();
        }

        // POST: Mensajes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Titulo,Descripcion,EstudianteId,UsuarioId")] Mensaje mensaje)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mensaje);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Apellido_M", mensaje.EstudianteId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Apellido_M", mensaje.UsuarioId);
            return View(mensaje);
        }

        // GET: Mensajes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensaje = await _context.Mensaje.FindAsync(id);
            if (mensaje == null)
            {
                return NotFound();
            }
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Apellido_M", mensaje.EstudianteId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Apellido_M", mensaje.UsuarioId);
            return View(mensaje);
        }

        // POST: Mensajes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Titulo,Descripcion,EstudianteId,UsuarioId")] Mensaje mensaje)
        {
            if (id != mensaje.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mensaje);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MensajeExists(mensaje.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstudianteId"] = new SelectList(_context.Estudiantes, "Id", "Apellido_M", mensaje.EstudianteId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "Id", "Apellido_M", mensaje.UsuarioId);
            return View(mensaje);
        }

        // GET: Mensajes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensaje = await _context.Mensaje
                .Include(m => m.Estudiante)
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mensaje == null)
            {
                return NotFound();
            }

            return View(mensaje);
        }

        // POST: Mensajes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mensaje = await _context.Mensaje.FindAsync(id);
            if (mensaje != null)
            {
                _context.Mensaje.Remove(mensaje);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensajeExists(int id)
        {
            return _context.Mensaje.Any(e => e.Id == id);
        }
    }
}
