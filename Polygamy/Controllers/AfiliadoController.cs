using Microsoft.AspNetCore.Http;
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

        // GET: Afiliados/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                _afiliadoGateway.crear(afiliado);
                return RedirectToAction("Index");
            }

            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Afiliados/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Afiliados/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Afiliados/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Afiliados/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}