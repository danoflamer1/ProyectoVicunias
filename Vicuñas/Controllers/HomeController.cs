using Micontexto.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Text.Json;
using Vicuñas.Models;

namespace Vicuñas.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContextoV _context;
        private readonly ILogger<HomeController> _logger;

        private const string SessionEstudianteKey = "Rude_Estudiante";
        private const string SessionPadresKey = "Rude_Padres";

        public HomeController(ILogger<HomeController> logger, ContextoV context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index() => View();
        public IActionResult Privacy() => View();

        // Mostrar formulario estudiante (leer desde sesión si existe)
        public async Task<IActionResult> RudeEstudiantes(int? estudianteId = null)
        {
            // Si viene Id explícito preféreselo (editar existente guardado en BD anteriormente)
            if (estudianteId.HasValue && estudianteId.Value != 0)
            {
                var estudianteDb = await _context.Estudiantes.AsNoTracking().FirstOrDefaultAsync(e => e.Id == estudianteId.Value);
                if (estudianteDb != null) return View(estudianteDb);
            }

            // Si hay estudiante en sesión, devolverlo para prellenar
            var jsonE = HttpContext.Session.GetString(SessionEstudianteKey);
            if (!string.IsNullOrEmpty(jsonE))
            {
                try
                {
                    var est = JsonSerializer.Deserialize<Estudiante>(jsonE);
                    if (est != null) return View(est);
                }
                catch { /* ignorar si no se deserializa */ }
            }

            return View(new Estudiante());
        }

        // Guardar estudiante EN SESIÓN, no en BD
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateEstudiante([Bind("Id,CI,Ci_Complemento,Ci_Expedido,Apellido_P,Apellido_M,Nombres,Sexo,Inscrito,Fecha_Nac,Discapacidad,Nro_Discapacidad,Tipo_Auditiva,Tipo_Visual,Tipo_Intelectual,Tipo_Fisica,Tipo_Mental,Tipo_Discapacidad,Programa_Apoyo,Extranjero,Tipo_Documento_Extranjero,Nro_Documento_Extranjero,Nro_Telefono,Nro_Celular,Pais,Departamento,Provincia,Municipio,Localidad,Zona,Direccion,Nro_Vivienda,Certificado_Oficialia,Certificado_Libro,Certificado_Partida,Certificado_Folio,Nro_Rude,ParaleloId")] Estudiante estudiante)
        {
            if (!ModelState.IsValid)
            {
                return View("RudeEstudiantes", estudiante);
            }

            // Guardar el objeto estudiante en sesión (serializado)
            var json = JsonSerializer.Serialize(estudiante);
            HttpContext.Session.SetString(SessionEstudianteKey, json);

            // Ir a la pantalla de padres (no se ha escrito nada en BD aún)
            return RedirectToAction("RudePadres");
        }

        // GET: RudePadres -> mostrar formulario; prellenar con padres en sesión si hay
        public IActionResult RudePadres()
        {
            // Si hay estudiante en sesión, pasar indicador a la vista
            var tieneEst = !string.IsNullOrEmpty(HttpContext.Session.GetString(SessionEstudianteKey));
            ViewData["TieneEstudianteEnSesion"] = tieneEst;
            var padresJson = HttpContext.Session.GetString(SessionPadresKey);
            ViewData["PadresJson"] = padresJson ?? "[]";
            return View();
        }

        // Guardar padres EN SESIÓN y enlazar temporalmente (no escribir en BD)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreatePadres([FromForm] List<Padre> padres, bool saveAndBack = false)
        {
            padres ??= new List<Padre>();

            // Limpiar entradas vacías
            for (int i = padres.Count - 1; i >= 0; i--)
            {
                if (string.IsNullOrWhiteSpace(padres[i].Nombres) && padres[i].CI == 0)
                {
                    padres.RemoveAt(i);
                }
            }

            // Guardar en sesión
            var json = JsonSerializer.Serialize(padres);
            HttpContext.Session.SetString(SessionPadresKey, json);

            if (saveAndBack)
                return RedirectToAction("RudeEstudiantes");

            // Ir a la página de inscripciones (final)
            return RedirectToAction("RudeInsripciones");
        }

        // Mostrar página de inscripciones (final) donde usuario confirmará y se persistirá todo
        public IActionResult RudeInsripciones()
        {
            // La vista puede leer desde Session via JS/hidden o controlador puede pasar los objetos
            var estudianteJson = HttpContext.Session.GetString(SessionEstudianteKey);
            var padresJson = HttpContext.Session.GetString(SessionPadresKey);

            if (!string.IsNullOrEmpty(estudianteJson))
            {
                ViewData["EstudianteJson"] = estudianteJson;
            }
            if (!string.IsNullOrEmpty(padresJson))
            {
                ViewData["PadresJson"] = padresJson;
            }

            return View();
        }

        // Reemplaza/añade este método en HomeController


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FinalizeInscripcion(int gradoId)
        {
            var estudianteJson = HttpContext.Session.GetString(SessionEstudianteKey);
            var padresJson = HttpContext.Session.GetString(SessionPadresKey);

            if (string.IsNullOrEmpty(estudianteJson))
                return BadRequest("No hay datos de estudiante en sesión.");

            var estudianteSession = JsonSerializer.Deserialize<Estudiante>(estudianteJson);
            var padresSession = string.IsNullOrEmpty(padresJson) ? new List<Padre>() : JsonSerializer.Deserialize<List<Padre>>(padresJson)!;

            if (estudianteSession == null)
                return BadRequest("Estudiante inválido.");

            Estudiante estudianteDb = await _context.Estudiantes
                .Include(e => e.Tutores)
                .FirstOrDefaultAsync(e => e.CI == estudianteSession.CI);

            if (estudianteDb == null)
            {
                _context.Estudiantes.Add(estudianteSession);
                await _context.SaveChangesAsync();
                estudianteDb = estudianteSession;
            }
            else
            {
                MergeEstudianteIfPresent(estudianteDb, estudianteSession);
                estudianteDb.Inscrito = true;
                _context.Update(estudianteDb);
                await _context.SaveChangesAsync();
            }

            var padresDbList = new List<Padre>();
            foreach (var p in padresSession)
            {
                Padre padreDb = null!;
                if (p.CI != 0)
                {
                    padreDb = await _context.Padres
                        .Include(x => x.Estudiantes)
                        .FirstOrDefaultAsync(x => x.CI == p.CI);
                }

                if (padreDb != null)
                {
                    MergePadreIfPresent(padreDb, p);
                    padreDb.Contraseña = BuildPassword(padreDb);
                    _context.Update(padreDb);
                }
                else
                {
                    p.Contraseña = BuildPassword(p);
                    p.Estudiantes = new List<Estudiante> { estudianteDb };
                    _context.Padres.Add(p);
                    padreDb = p;
                }

                padresDbList.Add(padreDb);

                padreDb.Estudiantes ??= new List<Estudiante>();
                if (!padreDb.Estudiantes.Any(e => e.Id == estudianteDb.Id))
                    padreDb.Estudiantes.Add(estudianteDb);
            }

            await _context.SaveChangesAsync();

            var paralelosQuery = _context.Paralelos
                .Include(p => p.Estudiantes)
                .Where(p => p.GradoId == gradoId && p.Disponibilidad);

            var candidato = await paralelosQuery
                .OrderBy(p => (p.Estudiantes == null ? 0 : p.Estudiantes.Count))
                .FirstOrDefaultAsync();

            Paralelo paraleloSeleccionado;
            if (candidato == null || (candidato.Estudiantes?.Count ?? 0) >= candidato.Cupo)
            {
                var grado = await _context.Set<Grado>().FindAsync(gradoId);
                var nextIndex = (await _context.Paralelos.Where(p => p.GradoId == gradoId).CountAsync()) + 1;
                paraleloSeleccionado = new Paralelo
                {
                    Nombre = grado != null ? $"{(grado.Nombre ?? $"G{grado.Id}")}-P{nextIndex}" : $"P-{gradoId}-{nextIndex}",
                    GradoId = gradoId,
                    Cupo = 30,
                    Disponibilidad = true,
                    Estudiantes = new List<Estudiante>()
                };
                _context.Paralelos.Add(paraleloSeleccionado);
                await _context.SaveChangesAsync();
            }
            else
            {
                paraleloSeleccionado = candidato;
            }

            paraleloSeleccionado.Estudiantes ??= new List<Estudiante>();
            if (!paraleloSeleccionado.Estudiantes.Any(e => e.Id == estudianteDb.Id))
                paraleloSeleccionado.Estudiantes.Add(estudianteDb);

            estudianteDb.ParaleloId = paraleloSeleccionado.Id;
            _context.Update(estudianteDb);
            await _context.SaveChangesAsync();

            var ins = new Inscripcion
            {
                Fecha = DateTime.UtcNow.Date,
                EstudianteCi = estudianteDb.CI,
                ParaleloId = paraleloSeleccionado.Id,
                UsuarioCi = 1,
                TutorCi = padresDbList.FirstOrDefault()?.CI
            };
            _context.Inscripciones.Add(ins);
            await _context.SaveChangesAsync();

            HttpContext.Session.Remove(SessionEstudianteKey);
            HttpContext.Session.Remove(SessionPadresKey);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CancelarInscripcion()
        {
            HttpContext.Session.Remove(SessionEstudianteKey);
            HttpContext.Session.Remove(SessionPadresKey);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteEstudiante(int id)
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString(SessionEstudianteKey)))
            {
                HttpContext.Session.Remove(SessionEstudianteKey);
                HttpContext.Session.Remove(SessionPadresKey);
                return RedirectToAction("Index");
            }

            var estudiante = await _context.Estudiantes.Include(e => e.Tutores).FirstOrDefaultAsync(e => e.Id == id);
            if (estudiante == null) return NotFound();

            var tutores = estudiante.Tutores?.ToList() ?? new List<Padre>();
            _context.Estudiantes.Remove(estudiante);
            await _context.SaveChangesAsync();

            foreach (var t in tutores)
            {
                var tutor = await _context.Padres.Include(x => x.Estudiantes).Include(x => x.Inscripciones).FirstOrDefaultAsync(x => x.Id == t.Id);
                if (tutor == null) continue;
                var tieneEstudiantes = tutor.Estudiantes != null && tutor.Estudiantes.Any();
                var tieneInscripciones = tutor.Inscripciones != null && tutor.Inscripciones.Any();
                if (!tieneEstudiantes && !tieneInscripciones) _context.Padres.Remove(tutor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private void MergeEstudianteIfPresent(Estudiante target, Estudiante source)
        {
            if (!string.IsNullOrWhiteSpace(source.Ci_Complemento)) target.Ci_Complemento = source.Ci_Complemento;
            if (!string.IsNullOrWhiteSpace(source.Ci_Expedido)) target.Ci_Expedido = source.Ci_Expedido;
            if (!string.IsNullOrWhiteSpace(source.Apellido_P)) target.Apellido_P = source.Apellido_P;
            if (!string.IsNullOrWhiteSpace(source.Apellido_M)) target.Apellido_M = source.Apellido_M;
            if (!string.IsNullOrWhiteSpace(source.Nombres)) target.Nombres = source.Nombres;
            if (!string.IsNullOrWhiteSpace(source.Pais)) target.Pais = source.Pais;
            if (!string.IsNullOrWhiteSpace(source.Departamento)) target.Departamento = source.Departamento;
            if (!string.IsNullOrWhiteSpace(source.Provincia)) target.Provincia = source.Provincia;
            if (!string.IsNullOrWhiteSpace(source.Municipio)) target.Municipio = source.Municipio;
            if (!string.IsNullOrWhiteSpace(source.Localidad)) target.Localidad = source.Localidad;
            if (!string.IsNullOrWhiteSpace(source.Zona)) target.Zona = source.Zona;
            if (!string.IsNullOrWhiteSpace(source.Direccion)) target.Direccion = source.Direccion;
            if (!string.IsNullOrWhiteSpace(source.Nro_Rude)) target.Nro_Rude = source.Nro_Rude;

            if (source.CI != 0) target.CI = source.CI;
            if (source.Nro_Telefono != 0) target.Nro_Telefono = source.Nro_Telefono;
            if (source.Nro_Celular != 0) target.Nro_Celular = source.Nro_Celular;

            if (!string.IsNullOrWhiteSpace(source.Sexo)) target.Sexo = source.Sexo;
            if (source.Fecha_Nac != default(DateOnly)) target.Fecha_Nac = source.Fecha_Nac;
            if (source.Discapacidad != default) target.Discapacidad = source.Discapacidad;
            if (!string.IsNullOrWhiteSpace(source.Nro_Discapacidad)) target.Nro_Discapacidad = source.Nro_Discapacidad;
        }
        private void MergePadreIfPresent(Padre target, Padre source)
        {
            if (!string.IsNullOrWhiteSpace(source.Apellido_P)) target.Apellido_P = source.Apellido_P;
            if (!string.IsNullOrWhiteSpace(source.Apellido_M)) target.Apellido_M = source.Apellido_M;
            if (!string.IsNullOrWhiteSpace(source.Nombres)) target.Nombres = source.Nombres;
            if (!string.IsNullOrWhiteSpace(source.Ci_Complemento)) target.Ci_Complemento = source.Ci_Complemento;
            if (!string.IsNullOrWhiteSpace(source.Ci_Expedido)) target.Ci_Expedido = source.Ci_Expedido;
            if (source.Fecha_Nac != default(DateTime)) target.Fecha_Nac = source.Fecha_Nac;
            if (!string.IsNullOrWhiteSpace(source.Idioma1)) target.Idioma1 = source.Idioma1;
            if (!string.IsNullOrWhiteSpace(source.Laburo)) target.Laburo = source.Laburo;
            if (!string.IsNullOrWhiteSpace(source.Educacion)) target.Educacion = source.Educacion;
            if (!string.IsNullOrWhiteSpace(source.Tipo_Tutor)) target.Tipo_Tutor = source.Tipo_Tutor;
        }

        private string BuildPassword(Padre p)
        {
            var complemento = string.IsNullOrWhiteSpace(p.Ci_Complemento) ? "" : p.Ci_Complemento.Trim();
            var partes = new[] { p.Apellido_P, p.Apellido_M, p.Nombres };
            var initials = string.Concat(partes
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(s => char.ToUpperInvariant(s.Trim()[0])));
            return $"{p.CI}{complemento}{initials}";
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}