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
    public class CompraDetalleController : Controller
    {
        private readonly ProductoGateway _productoGateway;
        private readonly CompraGateway _compraGateway;
        private readonly CompraDetalleGateway _compraDetalleGateway;

        public CompraDetalleController(IOptions<AppSettings> databaseSettings)
        {
            _productoGateway = new ProductoGateway(databaseSettings);
            _compraGateway = new CompraGateway(databaseSettings);
            _compraDetalleGateway = new CompraDetalleGateway(databaseSettings);
        }

        // GET: CompraDetalle/Create
        public ActionResult Create(int idCompra)
        {
            var productos = _productoGateway.listar().Select(p => new
            {
                Id = p.id,
                NombreCompleto = string.Format("{0} - {1} (COP)", p.descripcion, p.precioUnitario)
            })
            .ToList();

            TempData["idCompra"] = idCompra;
            ViewBag.Productos = new SelectList(productos, "Id", "NombreCompleto");

            return View();
        }

        // POST: CompraDetalle/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                int idProducto = Convert.ToInt32(collection["producto"].ToString());

                Compra compra = _compraGateway.obtener(Convert.ToInt32(TempData["idCompra"]));
                Producto producto = _productoGateway.obtener(idProducto);

                CompraDetalle compraDetalle = new CompraDetalle
                {
                    producto = producto,
                    cantidad = Convert.ToInt32(collection["cantidad"]),
                    compra = compra
                };

                _compraDetalleGateway.crear(compraDetalle);

                return RedirectToAction("Registrar", new { idBeneficiario = compra.beneficiario.idBeneficiario });
            }

            catch (Exception ex)
            {
                return View();
            }
        }
    }
}