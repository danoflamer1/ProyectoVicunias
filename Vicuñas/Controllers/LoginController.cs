using Micontexto.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace Vicuñas.Controllers
{
    public class LoginController : Controller
    {
        private ContextoV _context;
        public LoginController(ContextoV context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(int usuariol, string password)
        {
            var usuario = await _context.Usuarios
                .Where(x => x.CI == usuariol && x.Contraseña == password)
                .FirstOrDefaultAsync();
            if(usuario != null)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                var padre = await _context.Padres
                           .Where(x => x.CI == usuariol && x.Contraseña == password)
                           .FirstOrDefaultAsync();
                if (padre == null)
                {
                   TempData["LoginError"]="Usuario o Password incorrecto";
                    return RedirectToAction("Index"); ;
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }               
        }
    }
}