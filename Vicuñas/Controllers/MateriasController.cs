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
    public class MateriasController : Controller
    {
        private readonly ContextoV _context;

        public MateriasController(ContextoV context)
        {
            _context = context;
        }

        // GET: Materias
        // using Microsoft.EntityFrameworkCore; // asegúrate de tener este using

        public async Task<IActionResult> Index(int? gradoId, int? paraleloId, string searchName)
        {
            // Base query incluyendo relaciones necesarias
            var query = _context.Materias
                                .Include(m => m.Paralelo)
                                    .ThenInclude(p => p.Grado)
                                .AsQueryable();

            // Filtrar por grado (si se selecciona)
            if (gradoId.HasValue)
            {
                // Filtra materias cuyo paralelo pertenece al grado seleccionado
                query = query.Where(m => m.Paralelo != null && m.Paralelo.GradoId == gradoId.Value);
            }

            // Filtrar por paralelo (si se selecciona)
            if (paraleloId.HasValue)
            {
                query = query.Where(m => m.ParaleloId == paraleloId.Value);
            }

            // Filtrar por nombre (opcional)
            if (!string.IsNullOrWhiteSpace(searchName))
            {
                query = query.Where(m => (m.Nombre ?? "").Contains(searchName));
            }

            // Obtener listas para los dropdowns
            var gradosList = await _context.Grados.OrderBy(g => g.Numero).ToListAsync();

            // Si se seleccionó grado, limitar paralelos a ese grado; si no, todos.
            var paralelosQuery = _context.Paralelos.AsQueryable();
            if (gradoId.HasValue)
            {
                paralelosQuery = paralelosQuery.Where(p => p.GradoId == gradoId.Value);
            }
            var paralelosList = await paralelosQuery.OrderBy(p => p.Nombre).ToListAsync();

            ViewData["GradoId"] = new SelectList(gradosList, "Id", "Nombre", gradoId);
            ViewData["ParaleloId"] = new SelectList(paralelosList, "Id", "Nombre", paraleloId);

            var lista = await query.AsNoTracking().ToListAsync();
            return View(lista);
        }




        // GET: Materias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias
                .Include(m => m.Paralelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        // GET: Materias/Create
        public IActionResult Create()
        {
            ViewData["ParaleloId"] = new SelectList(_context.Paralelos, "Id", "Nombre");
            return View();
        }

        // POST: Materias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,UsuarioCi,ParaleloId")] Materia materia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParaleloId"] = new SelectList(_context.Paralelos, "Id", "Nombre", materia.ParaleloId);
            return View(materia);
        }

        // GET: Materias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias.FindAsync(id);
            if (materia == null)
            {
                return NotFound();
            }
            ViewData["ParaleloId"] = new SelectList(_context.Paralelos, "Id", "Nombre", materia.ParaleloId);
            return View(materia);
        }

        // POST: Materias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,UsuarioCi,ParaleloId")] Materia materia)
        {
            if (id != materia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MateriaExists(materia.Id))
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
            ViewData["ParaleloId"] = new SelectList(_context.Paralelos, "Id", "Nombre", materia.ParaleloId);
            return View(materia);
        }

        // GET: Materias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materia = await _context.Materias
                .Include(m => m.Paralelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (materia == null)
            {
                return NotFound();
            }

            return View(materia);
        }

        // POST: Materias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materia = await _context.Materias.FindAsync(id);
            if (materia != null)
            {
                _context.Materias.Remove(materia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MateriaExists(int id)
        {
            return _context.Materias.Any(e => e.Id == id);
        }
    }
}
