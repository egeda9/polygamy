using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polygamy.Models;
using Polygamy.Data;
using Polygamy.Security;
using Microsoft.AspNetCore.Http;

namespace Polygamy.Controllers
{    
    public class AccountController : Controller
    {
        private readonly ILogger _logger;
        private UsuarioGateway _usuarioGateway;
        private Encripcion _encriptar;

        const string SessionKeyName = "_NombreUsuario";

        public AccountController(
            IOptions<IdentityCookieOptions> identityCookieOptions,
            ILoggerFactory loggerFactory,
            IOptions<AppSettings> databaseSettings)
        {
            _logger = loggerFactory.CreateLogger<AccountController>();

            _usuarioGateway = new UsuarioGateway(databaseSettings);
            _encriptar = new Encripcion();
        }

        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Login(Usuario usuario, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            bool formatoContrasenaValida = usuario.comprobarContrasenaSegura();
            if (!formatoContrasenaValida)
            {
                ViewBag.Messages = new[] {
                    new AlertViewModel("danger", "Error", "Formato de Contraseña Inválida")
                };
                return View(usuario);
            }

            string contrasenaEncriptada = _encriptar.encriptarContrasena(usuario.contrasena);
            Usuario usuarioAlmacenado   = _usuarioGateway.obtener(contrasenaEncriptada, usuario.nombreUsuario.ToLower());

            if (usuarioAlmacenado != null)
            {
                _logger.LogInformation(1, "Usuario válido");
                if (HttpContext.Session != null) HttpContext.Session.Set(SessionKeyName, usuario.nombreUsuario.ToLower());
                return RedirectToLocal(returnUrl);
            }

            else
            {
                ViewBag.Messages = new[] {
                    new AlertViewModel("danger", "Error", "Usuario o contraseña inválidos")
                };
                return View(usuario);
            }
        }

        //
        // GET: /Account/Register
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Usuario usuario, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                _usuarioGateway.crear(usuario);
            }

            // If we got this far, something failed, redisplay form
            return View(usuario);
        }

        //
        // POST: /Account/Logout
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Logout()
        {
            HttpContext.Session.Set(SessionKeyName, string.Empty);
            _logger.LogInformation(4, "El usuario ha salido de la aplicación");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        //
        // GET /Account/AccessDenied
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        #region Helpers

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
        }

        #endregion
    }
}
