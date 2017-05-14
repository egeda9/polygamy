using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Polygamy.Data;
using Polygamy.Models;

namespace Polygamy.Controllers
{
    [Authorize]
    public class BeneficiarioController : Controller
    {
        private readonly IOptions<AppSettings> _databaseSettings;

        public BeneficiarioController(IOptions<AppSettings> databaseSettings)
        {
            _databaseSettings = databaseSettings;
        }

        // GET: Beneficiarios
        public ActionResult Index()
        {
            BeneficiarioGateway beneficiarioGateway = new BeneficiarioGateway(_databaseSettings);
            return View(beneficiarioGateway.listar());
        }

        // GET: Beneficiarios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Beneficiarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Beneficiarios/Create
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

        // GET: Beneficiarios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Beneficiarios/Edit/5
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

        // GET: Beneficiarios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Beneficiarios/Delete/5
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