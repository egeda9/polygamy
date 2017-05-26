using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Polygamy.Data;
using Polygamy.Models;
using System;
using System.Linq;

namespace Polygamy.Controllers
{
    public class CompraController : Controller
    {
        private readonly BeneficiarioGateway _beneficiarioGateway;
        private readonly SupermercadoGateway _supermercadoGateway;
        private readonly CompraGateway _compraGateway;        

        public CompraController(IOptions<AppSettings> databaseSettings)
        {
            _beneficiarioGateway = new BeneficiarioGateway(databaseSettings);
            _supermercadoGateway = new SupermercadoGateway(databaseSettings);
            _compraGateway = new CompraGateway(databaseSettings);            
        }

        // GET: Compra
        public ActionResult Validar()
        {
            return View();
        }

        // POST: Compra/Validar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Validar(IFormCollection collection)
        {
            try
            {
                int identificacion = Convert.ToInt32(collection["identificacion"]);
                Beneficiario beneficiario = _beneficiarioGateway.obtenerPorIdentificacion(identificacion);

                if (beneficiario == null)
                {
                    ViewBag.Messages = new[] {
                        new AlertViewModel("warning", "Aviso", "El beneficiario no existe")
                    };
                    return View();
                }

                else if (!beneficiario.activo)
                {
                    ViewBag.Messages = new[] {
                        new AlertViewModel("warning", "Aviso", "Beneficiario inactivo")
                    };
                    return View();
                }

                else if (!BetweenDates(DateTime.Now.Date, beneficiario.fechaCompraInicio, beneficiario.fechaCompraFin))
                {
                    ViewBag.Messages = new[] {
                        new AlertViewModel("warning", "Aviso", "No puede registrarse la compra, fecha de compra no autorizada")
                    };
                    return View();
                }
                return RedirectToAction("Registrar", new { idBeneficiario = beneficiario.idBeneficiario });
            }

            catch (Exception ex)
            {
                ViewBag.Messages = new[] {
                    new AlertViewModel("danger", "Error en el proceso: ", ex.Message)
                };
                return View();
            }
        }
        
        public ActionResult Registrar(int idBeneficiario)
        {
            var afiliados = _supermercadoGateway.listar().Select(s => new
            {
                Id = s.id,
                NombreCompleto = string.Format("{0} - {1}", s.ciudad, s.direccion)
            })
            .ToList();

            TempData["idBeneficiario"] = idBeneficiario;
            ViewBag.Supermercados = new SelectList(afiliados, "Id", "NombreCompleto");

            return View();
        }

        // POST: Compra/Registrar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registrar(IFormCollection collection)
        {
            try
            {
                Supermercado supermercado = _supermercadoGateway.obtener(Convert.ToInt32(collection["supermercado"]));
                Beneficiario beneficiario = _beneficiarioGateway.obtenerPorId(Convert.ToInt32(TempData["idBeneficiario"]));

                Compra compra = new Compra
                {
                    supermercado = supermercado,
                    beneficiario = beneficiario,
                    fecha = DateTime.Now
                };

                int idCompra = _compraGateway.crear(compra);
                return RedirectToAction("Create", "CompraDetalle", new { idCompra = idCompra });
            }

            catch (Exception ex)
            {
                return View();
            }
        }        

        private bool BetweenDates(DateTime input, DateTime date1, DateTime date2)
        {
            return (input >= date1 && input <= date2);
        }
    }
}