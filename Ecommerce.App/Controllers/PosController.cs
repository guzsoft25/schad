using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.App.Controllers
{
    public class PosController : Controller
    {
        // GET: PosController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PosController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PosController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PosController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
