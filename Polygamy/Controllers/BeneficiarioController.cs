using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Polygamy.Data;
using Polygamy.Models;
using System;
using System.Globalization;
using System.Linq;

namespace Polygamy.Controllers
{
    //[Authorize]
    public class BeneficiarioController : Controller
    {
        private BeneficiarioGateway _beneficiarioGateway;
        private AfiliadoGateway _afiliadoGateway;

        public BeneficiarioController(IOptions<AppSettings> databaseSettings)
        {
            _beneficiarioGateway = new BeneficiarioGateway(databaseSettings);
            _afiliadoGateway = new AfiliadoGateway(databaseSettings);
        }

        // GET: Beneficiarios
        public ActionResult Index()
        {
            return View(_beneficiarioGateway.listar());
        }

        // GET: Beneficiarios/Create
        public ActionResult Create()
        {
            var afiliados = _afiliadoGateway.listar().Select(a => new
            {
                Id = a.id,
                NombreCompleto = string.Format("{0} {1}", a.nombres, a.apellidos)
            })
            .ToList();

            ViewBag.Afiliados = new SelectList(afiliados, "Id", "NombreCompleto");
            return View();
        }

        // POST: Beneficiarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                Afiliado afiliado =_afiliadoGateway.obtener(Convert.ToInt32(collection["afiliado"]));

                Beneficiario beneficiario = new Beneficiario
                {
                    activo = Convert.ToBoolean(collection["activo"].ToString().Split(',')[0]),
                    apellidos = collection["apellidos"],
                    ciudadResidencia = collection["ciudadResidencia"],
                    cupo = float.Parse(collection["cupo"], CultureInfo.InvariantCulture.NumberFormat),
                    direccionResidencia = collection["direccionResidencia"],
                    email = collection["email"],
                    nombres = collection["nombres"],
                    identificacion = Convert.ToInt32(collection["identificacion"]),
                    numeroTelefono = Convert.ToInt64(collection["numeroTelefono"]),
                    fechaCompraFin = Convert.ToDateTime(collection["fechaCompraFin"]),
                    fechaCompraInicio = Convert.ToDateTime(collection["fechaCompraInicio"]),
                    id = Convert.ToInt32(collection["id"]),
                    afiliado = afiliado
                };

                int personaId = _beneficiarioGateway.crear(beneficiario);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}