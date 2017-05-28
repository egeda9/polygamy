using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Polygamy.Data;
using Polygamy.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace Polygamy.Controllers
{
    public class ReporteController : Controller
    {
        private readonly CompraGateway _compraGateway;
        private readonly ILogger _logger;
        private readonly IHostingEnvironment _hostingEnvironment;

        private const string tituloArchivo = "Valores maximos de compra";
        private const string autorArchivo = "IngSoft2017";

        public ReporteController(IOptions<AppSettings> databaseSettings, ILoggerFactory loggerFactory, IHostingEnvironment hostingEnvironment)
        {
            _compraGateway = new CompraGateway(databaseSettings, loggerFactory);
            _logger = loggerFactory.CreateLogger<ReporteController>();
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Reporte
        public ActionResult Index()
        {
            return View();
        }

        // POST: Reporte/Create
        [HttpPost]
        public JsonResult Create(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                List<Compra> compras =_compraGateway.obtener(fechaInicio, fechaFin);
                string mensaje = string.Empty;
                if (!compras.Any())
                {
                    mensaje = "El reporte no contiene registros";
                }                    

                else
                {
                    mensaje = "Reporte generado exitosamente";
                    ExportarReporte(compras);                    
                }
                return Json(mensaje);
            }

            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return Json(ex);
            }
        }

        private void ExportarReporte(List<Compra> compras)
        {
            string webRootFolder = _hostingEnvironment.WebRootPath;
            string nombreArchivo = @"maximos-valores-compra.xlsx";
            string url = string.Format("{0}://{1}/{2}", Request.Scheme, Request.Host, nombreArchivo);
            FileInfo archivo = new FileInfo(Path.Combine(webRootFolder, nombreArchivo));

            if (archivo.Exists)
            {
                archivo.Delete();
                archivo = new FileInfo(Path.Combine(webRootFolder, nombreArchivo));
            }

            using (ExcelPackage package = new ExcelPackage(archivo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("maximos-valores-compra");

                worksheet.Cells[1, 1].Value = "Fecha";
                worksheet.Cells[1, 2].Value = "Total (COP)";
                worksheet.Cells[1, 3].Value = "Supermercado";
                worksheet.Cells[1, 4].Value = "Beneficiario";

                worksheet.Column(1).AutoFit();
                worksheet.Column(2).AutoFit();
                worksheet.Column(3).AutoFit();
                worksheet.Column(4).AutoFit();

                worksheet.Column(1).Style.Numberformat.Format = "yyyy-mm-dd";
                worksheet.Column(2).Style.Numberformat.Format = "#,##0.00;(#,##0.00)";

                using (var range = worksheet.Cells[1, 1, 1, 4])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.Black);
                    range.Style.Font.Color.SetColor(Color.WhiteSmoke);
                    range.Style.ShrinkToFit = false;
                }

                package.Workbook.Properties.Author = autorArchivo;
                package.Workbook.Properties.Company = autorArchivo;

                for (int i=0;i<compras.Count;i++)
                {
                    int indice = i + 2;

                    worksheet.Cells["A" + indice].Value = compras[i].fecha;
                    worksheet.Cells["B" + indice].Value = compras[i].total;
                    worksheet.Cells["C" + indice].Value = compras[i].supermercado.ciudad + " - " + compras[i].supermercado.direccion;
                    worksheet.Cells["D" + indice].Value = compras[i].beneficiario.nombres + " " + compras[i].beneficiario.apellidos;
                }
                package.Save();
            }
        }
    }
}