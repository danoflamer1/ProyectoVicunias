using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Micontexto.Context;
using Vicuñas.Models;

using ClosedXML.Excel;
using System.Data;
using Microsoft.AspNetCore.Authorization;


namespace Vicuñas.Controllers
{
    [Authorize(Roles = "Administrador, Maestro, Tutor")]
    public class ParaleloesController : Controller
    {
        public async Task<IActionResult> ExportarExcel()
        {
            var estudiantes = await _context.Estudiantes
                .Include(e => e.Paralelo)
                .OrderBy(e => e.Paralelo != null ? e.Paralelo.Nombre : "")
                .ToListAsync();

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Estudiantes");
                var currentRow = 1;

                // Encabezados
                worksheet.Cell(currentRow, 1).Value = "CI";
                worksheet.Cell(currentRow, 2).Value = "Nombres";
                worksheet.Cell(currentRow, 3).Value = "Apellido Paterno";
                worksheet.Cell(currentRow, 4).Value = "Apellido Materno";
                worksheet.Cell(currentRow, 5).Value = "Paralelo";

                // Filas
                foreach (var e in estudiantes)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = e.CI;
                    worksheet.Cell(currentRow, 2).Value = e.Nombres;
                    worksheet.Cell(currentRow, 3).Value = e.Apellido_P;
                    worksheet.Cell(currentRow, 4).Value = e.Apellido_M;
                    worksheet.Cell(currentRow, 5).Value = e.Paralelo?.Nombre ?? "-";
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Lista_Estudiantes.xlsx");
                }
            }
        }





        private readonly ContextoV _context;

        public ParaleloesController(ContextoV context)
        {
            _context = context;
        }

        // GET: Paraleloes
        public async Task<IActionResult> Index(int? gradoId, int? paraleloId)
        {
            var grados = await _context.Grados.ToListAsync();
            var paralelos = await _context.Paralelos.ToListAsync();

            var query = _context.Paralelos.Include(p => p.Grado).Include(p => p.Usuario).AsQueryable();

            if (gradoId.HasValue)
                query = query.Where(p => p.GradoId == gradoId);

            if (paraleloId.HasValue)
                query = query.Where(p => p.Id == paraleloId);

            ViewData["GradoId"] = new SelectList(grados, "Id", "Nombre");
            ViewData["ParaleloId"] = new SelectList(paralelos, "Id", "Nombre");

            return View(await query.ToListAsync());
        }

        // GET: Paraleloes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paralelo = await _context.Paralelos
                .Include(p => p.Grado)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (paralelo == null)
            {
                return NotFound();
            }

            // Obtener estudiantes del paralelo
            var estudiantes = await _context.Estudiantes
                .Where(e => e.ParaleloId == id)
                .ToListAsync();

            ViewBag.Estudiantes = estudiantes;
            // Obtener estudiantes del paralelo
            var materias = await _context.Estudiantes
                .Where(e => e.ParaleloId == id)
                .ToListAsync();

            ViewBag.Materias = materias;

            return View(paralelo);
        }

        // GET: Paraleloes/Create
        public IActionResult Create()
        {
            ViewData["GradoId"] = new SelectList(_context.Grados, "Id", "Nombre");
            var usuariosList = _context.Usuarios
            .Where(u => u.Rol == Dtos.Rolenum.Maestro)
            .ToList()
            .Select(u => new {
                Id = u.Id,
                NombreCompleto = u.Nombres + " " + u.Apellido_P + " " + u.Apellido_M
            })
            .ToList();
            ViewData["UsuarioId"] = new SelectList(usuariosList, "Id", "NombreCompleto");
            return View();
        }

        // POST: Paraleloes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Cupo,Disponibilidad,GradoId,UsuarioId")] Paralelo paralelo)
        {
            paralelo.Disponibilidad = true;
            if (ModelState.IsValid)
            {
                _context.Add(paralelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GradoId"] = new SelectList(_context.Grados, "Id", "Nombre", paralelo.GradoId);
            var usuariosList = _context.Usuarios
            .Where(u => u.Rol == Dtos.Rolenum.Maestro)
            .ToList()
            .Select(u => new {
                Id = u.Id,
                NombreCompleto = u.Nombres + " " + u.Apellido_P + " " + u.Apellido_M
            })
            .ToList();
            ViewData["UsuarioId"] = new SelectList(usuariosList, "Id", "NombreCompleto");
            return View(paralelo);
        }

        // GET: Paraleloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paralelo = await _context.Paralelos.FindAsync(id);
            if (paralelo == null)
            {
                return NotFound();
            }
            ViewData["GradoId"] = new SelectList(_context.Grados, "Id", "Nombre", paralelo.GradoId);
            var usuariosList = _context.Usuarios
            .Where(u => u.Rol == Dtos.Rolenum.Maestro)
            .ToList()
            .Select(u => new {
                Id = u.Id,
                NombreCompleto = u.Nombres + " " + u.Apellido_P + " " + u.Apellido_M
            })
            .ToList();
            ViewData["UsuarioId"] = new SelectList(usuariosList, "Id", "NombreCompleto");
            return View(paralelo);
        }

        // POST: Paraleloes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Cupo,Disponibilidad,GradoId,UsuarioId")] Paralelo paralelo)
        {
            if (id != paralelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paralelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParaleloExists(paralelo.Id))
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
            ViewData["GradoId"] = new SelectList(_context.Grados, "Id", "Nombre", paralelo.GradoId);
            var usuariosList = _context.Usuarios
            .Where(u => u.Rol == Dtos.Rolenum.Maestro)
            .ToList()
            .Select(u => new {
                Id = u.Id,
                NombreCompleto = u.Nombres + " " + u.Apellido_P + " " + u.Apellido_M
            })
            .ToList();
            ViewData["UsuarioId"] = new SelectList(usuariosList, "Id", "NombreCompleto");
            return View(paralelo);
        }

        // GET: Paraleloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paralelo = await _context.Paralelos
                .Include(p => p.Grado)
                .Include(p => p.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paralelo == null)
            {
                return NotFound();
            }

            return View(paralelo);
        }

        // POST: Paraleloes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paralelo = await _context.Paralelos.FindAsync(id);
            if (paralelo != null)
            {
                _context.Paralelos.Remove(paralelo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParaleloExists(int id)
        {
            return _context.Paralelos.Any(e => e.Id == id);
        }
    }
}
