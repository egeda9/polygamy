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
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;
        private readonly string _externalCookieScheme;
        private UsuarioGateway _usuarioGateway;
        private Encripcion _encriptar;

        const string SessionKeyName = "_NombreUsuario";

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<IdentityCookieOptions> identityCookieOptions,
            ILoggerFactory loggerFactory,
            IOptions<AppSettings> databaseSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _externalCookieScheme = identityCookieOptions.Value.ExternalCookieAuthenticationScheme;
            _logger = loggerFactory.CreateLogger<AccountController>();

            _usuarioGateway = new UsuarioGateway(databaseSettings);
            _encriptar = new Encripcion();
        }

        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.Authentication.SignOutAsync(_externalCookieScheme);

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
            Usuario usuarioAlmacenado   = _usuarioGateway.obtener(contrasenaEncriptada, usuario.nombreUsuario);

            if (usuarioAlmacenado != null)
            {
                _logger.LogInformation(1, "Usuario válido");
                if (HttpContext.Session != null) HttpContext.Session.Set(SessionKeyName, usuario.nombreUsuario);
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
                //if (result.Succeeded)
                //{
                //    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
                //    // Send an email with this link
                //    //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //    //var callbackUrl = Url.Action(nameof(ConfirmEmail), "Account", new { userId = user.Id, code = code }, protocol: HttpContext.Request.Scheme);
                //    //await _emailSender.SendEmailAsync(model.Email, "Confirm your account",
                //    //    $"Please confirm your account by clicking this link: <a href='{callbackUrl}'>link</a>");
                //    await _signInManager.SignInAsync(user, isPersistent: false);
                //    _logger.LogInformation(3, "User created a new account with password.");
                //    return RedirectToLocal(returnUrl);
                //}
                //AddErrors(result);
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
