using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Micontexto.Context;
using Vicuñas.Models;
using Microsoft.AspNetCore.Authorization;
using Vicuñas.ViewModels;

namespace Vicuñas.Controllers
{
    [Authorize (Roles = "Administrador, Secretaria, Tutor")]
    public class EstudiantesController : Controller
    {
        private readonly ContextoV _context;

        public EstudiantesController(ContextoV context)
        {
            _context = context;
        }

        // GET: Estudiantes


        // EstudiantesController.cs
        public async Task<IActionResult> Index(string searchName)
        {
            // Query base incluyendo la relación Paralelo
            var query = _context.Estudiantes
                                .Include(e => e.Paralelo)   // <-- importante
                                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchName))
            {
                query = query.Where(e =>
                    (e.Nombres ?? "").Contains(searchName) ||
                    (e.Apellido_P ?? "").Contains(searchName) ||
                    (e.Apellido_M ?? "").Contains(searchName));
            }

            var lista = await query.AsNoTracking().ToListAsync();
            return View(lista); // nunca es null, al menos devuelve una lista vacía
        }



        // GET: Estudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var estudiante = await _context.Estudiantes
                .Include(e => e.Paralelo)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (estudiante == null)
                return NotFound();

            //Mensajes dirigidos a este estudiante
      /*    var mensajes = await _context.Mensajes
                .Where(m => m.EstudianteId == id)
                .ToListAsync();
      */
            // Último trimestre: asumimos el mayor valor de Trimestre
            var ultimoTrimestre = await _context.Notas
                .Where(n => n.EstudianteCi == estudiante.CI)
                .MaxAsync(n => n.Trimestre);

            var notas = await _context.Notas
                .Include(n => n.Materia)
                .Where(n => n.EstudianteCi == estudiante.CI && n.Trimestre == ultimoTrimestre)
                .ToListAsync();

            var viewModel = new EstudianteDetailsViewModel
            {
                Estudiante = estudiante,
              //  Mensajes = mensajes,
                Notas = notas
            };

            return View(viewModel);
        }





        // GET: Estudiantes/Create
        public IActionResult Create()
        {
            ViewData["ParaleloId"] = new SelectList(_context.Paralelos, "Id", "Nombre");
            return View();
        }

        // POST: Estudiantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CI,Ci_Complemento,Ci_Expedido,Apellido_P,Apellido_M,Nombres,Sexo,Fecha_Nac,Discapacidad,Nro_Discapacidad,Tipo_Auditiva,Tipo_Visual,Tipo_Intelectual,Tipo_Fisica,Tipo_Mental,Tipo_Discapacidad,Programa_Apoyo,Extranjero,Tipo_Documento_Extranjero,Nro_Documento_Extranjero,Nro_Telefono,Nro_Celular,Pais,Departamento,Provincia,Municipio,Localidad,Zona,Direccion,Nro_Vivienda,Certificado_Oficialia,Certificado_Libro,Certificado_Partida,Certificado_Folio,Nro_Rude,ParaleloId")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParaleloId"] = new SelectList(_context.Paralelos, "Id", "Nombre", estudiante.ParaleloId);
            return View(estudiante);
        }

        // GET: Estudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            ViewData["ParaleloId"] = new SelectList(_context.Paralelos, "Id", "Nombre", estudiante.ParaleloId);
            return View(estudiante);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CI,Ci_Complemento,Ci_Expedido,Apellido_P,Apellido_M,Nombres,Sexo,Fecha_Nac,Discapacidad,Nro_Discapacidad,Tipo_Auditiva,Tipo_Visual,Tipo_Intelectual,Tipo_Fisica,Tipo_Mental,Tipo_Discapacidad,Programa_Apoyo,Extranjero,Tipo_Documento_Extranjero,Nro_Documento_Extranjero,Nro_Telefono,Nro_Celular,Pais,Departamento,Provincia,Municipio,Localidad,Zona,Direccion,Nro_Vivienda,Certificado_Oficialia,Certificado_Libro,Certificado_Partida,Certificado_Folio,Nro_Rude,ParaleloId")] Estudiante estudiante)
        {
            if (id != estudiante.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteExists(estudiante.Id))
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
            ViewData["ParaleloId"] = new SelectList(_context.Paralelos, "Id", "Nombre", estudiante.ParaleloId);
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiantes
                .Include(e => e.Paralelo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiante = await _context.Estudiantes.FindAsync(id);
            if (estudiante != null)
            {
                _context.Estudiantes.Remove(estudiante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteExists(int id)
        {
            return _context.Estudiantes.Any(e => e.Id == id);
        }
    }
}

