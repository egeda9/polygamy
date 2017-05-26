using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Polygamy.Data;
using Polygamy.Models;
using System;

namespace Polygamy.Controllers
{
    public class AfiliadoController : Controller
    {
        private readonly AfiliadoGateway _afiliadoGateway;

        public AfiliadoController(IOptions<AppSettings> databaseSettings)
        {
            _afiliadoGateway = new AfiliadoGateway(databaseSettings);
        }

        // GET: Afiliados
        public ActionResult Index()
        {
            return View(_afiliadoGateway.listar());
        }

        // GET: Afiliados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Afiliados/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("id,identificacion,nombres,apellidos,numeroTelefono,email,direccionResidencia,ciudadResidencia,cupo")] Afiliado afiliado)
        {
            try
            {
                bool resultadoProceso = _afiliadoGateway.crear(afiliado);
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                ViewBag.Messages = new[] {
                    new AlertViewModel("danger", "Error en el proceso: ", ex.Message)
                };
                return View();
            }
        }
    }
}