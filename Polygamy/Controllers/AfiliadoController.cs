using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Polygamy.Data;
using Polygamy.Models;

namespace Polygamy.Controllers
{
    [Authorize]
    public class AfiliadoController : Controller
    {
        private readonly IOptions<AppSettings> _databaseSettings;

        public AfiliadoController(IOptions<AppSettings> databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }

        // GET: Afiliados
        public ActionResult Index()
        {
            AfiliadoGateway afiliadoGateway = new AfiliadoGateway(_databaseSettings);
            return View(afiliadoGateway.listar());
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
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
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