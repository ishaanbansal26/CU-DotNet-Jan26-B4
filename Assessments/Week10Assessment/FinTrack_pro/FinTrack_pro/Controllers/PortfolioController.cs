using FinTrack_pro.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinTrack_pro.Controllers
{
    public class PortfolioController : Controller
    {
        private static List<Asset> assetlist = [
            new Asset()
            {
                AssetId=1,
                AssetName="Rocky",
                Amount=1000
            },
            new Asset()
            {
                AssetId=2,
                AssetName="Roshan",
                Amount=2000
            }
            ];
        // GET: PortfolioController
        public ActionResult Index()
        {
            return View(model: assetlist);
        }

        // GET: PortfolioController/Details/5
        [Route("Asset/Info/{id:int}")]
        public ActionResult Details(int id)
        {
            var x = assetlist.Find(x => x.AssetId == id);
            return View(x);
        }

        // GET: PortfolioController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PortfolioController/Create
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

        // GET: PortfolioController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PortfolioController/Edit/5
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

        // GET: PortfolioController/Delete/5
        public ActionResult Delete(int id)
        {
            var x = assetlist.Find(i => i.AssetId == id);
            return View(x);
        }

        // POST: PortfolioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Asset asset)
        {
                var x = assetlist.Find(i => i.AssetId == id);
                if (x != null)
                    assetlist.Remove(x);
                TempData["Message"] = "Asset Deleted Successfully";
                return RedirectToAction(nameof(Index));
        }
    }
}
