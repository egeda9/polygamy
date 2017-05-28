using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Polygamy.Data;
using Polygamy.Enum;
using Polygamy.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Polygamy.Controllers
{
    public class CompraDetalleController : Controller
    {
        private readonly ProductoGateway _productoGateway;
        private readonly CompraGateway _compraGateway;
        private readonly CompraDetalleGateway _compraDetalleGateway;
        private readonly BeneficiarioGateway _beneficiarioGateway;
        private readonly AfiliadoGateway _afiliadoGateway;
        private readonly ILogger _logger;

        public CompraDetalleController(IOptions<AppSettings> databaseSettings, ILoggerFactory loggerFactory)
        {
            _productoGateway = new ProductoGateway(databaseSettings);
            _compraGateway = new CompraGateway(databaseSettings, loggerFactory);
            _compraDetalleGateway = new CompraDetalleGateway(databaseSettings, loggerFactory);
            _beneficiarioGateway = new BeneficiarioGateway(databaseSettings, loggerFactory);
            _afiliadoGateway = new AfiliadoGateway(databaseSettings, loggerFactory);
            _logger = loggerFactory.CreateLogger<CompraDetalleController>();
        }

        // GET: CompraDetalle/Create
        public ActionResult Create(int idCompra, int tipoMensaje = 0)
        {
            var productos = _productoGateway.listar().Select(p => new
            {
                Id = p.id,
                NombreCompleto = string.Format("{0} - {1} (COP)", p.descripcion, p.precioUnitario)
            })
            .ToList();
            
            ViewBag.Productos = new SelectList(productos, "Id", "NombreCompleto");
            if (tipoMensaje > 0)
            {
                string mensaje = tipoMensaje == 1 ? "Cupo insuficiente para beneficiario" : "Cupo insuficiente para afiliado";
                ViewBag.Messages = new[] {
                        new AlertViewModel("warning", "Aviso", mensaje)
                    };                
            }

            TempData["idCompra"] = idCompra;
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

                Compra compra = _compraGateway.obtener(Convert.ToInt32(collection["compra"]));
                Producto producto = _productoGateway.obtener(idProducto);

                CompraDetalle compraDetalle = new CompraDetalle
                {
                    producto = producto,
                    cantidad = Convert.ToInt32(collection["cantidad"]),
                    compra = compra
                };

                float totalCompra = (compraDetalle.cantidad * compraDetalle.producto.precioUnitario) + compra.total;

                if (compra.beneficiario.cupo < totalCompra)
                    return RedirectToAction("Create", new { idCompra = compra.id, tipoMensaje = (int)MensajeEnum.CupoBeneficiario });

                else if (compra.beneficiario.afiliado.cupo < totalCompra)
                    return RedirectToAction("Create", new { idCompra = compra.id, tipoMensaje = (int)MensajeEnum.CupoAfiliado });

                else
                {
                    _compraDetalleGateway.crear(compraDetalle);

                    float cupoAfiliado = compra.beneficiario.afiliado.cupo - (compraDetalle.cantidad * compraDetalle.producto.precioUnitario);
                    compra.beneficiario.afiliado.cupo = cupoAfiliado;
                    _afiliadoGateway.actualizar(compra.beneficiario.afiliado);

                    compra.total = totalCompra;
                    _compraGateway.actualizar(compra);
                }

                return RedirectToAction("List", new { idCompra = compra.id });
            }

            catch (Exception ex)
            {
                ViewBag.Messages = new[] {
                    new AlertViewModel("danger", "Error en el proceso", ex.Message)
                };

                _logger.LogError(ex.Message, ex);
                return View();
            }
        }

        // GET: CompraDetalle/List
        public ActionResult List(int idCompra)
        {
            TempData["idCompra"] = idCompra;
            List<CompraDetalle> comprasDetalle = _compraDetalleGateway.listar(idCompra);
            return View(comprasDetalle);
        }
    }
}