using System.Security.Claims;
using System.Security.Policy;
using Micontexto.Context;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using Vicuñas.Models;

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
                await SetUserCookie(usuario);
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
                    await SetPadreCookie(padre);
                    return RedirectToAction("Index", "Home");
                }
            }               
        }

        private async Task SetPadreCookie(Padre padre)
        {
            var claims = new List<Claim>()
            {
            new Claim(ClaimTypes.Name, padre!.Nombres!),
            new Claim(ClaimTypes.Role, "Tutor"),
            new Claim(ClaimTypes.NameIdentifier, padre!.Id.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }

        private async Task SetUserCookie(Usuario usuario)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario!.Nombres!),
                new Claim(ClaimTypes.Role, usuario!.Rol.ToString()),
                new Claim(ClaimTypes.NameIdentifier, usuario!.Id.ToString())
            };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
        }
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
    }
}