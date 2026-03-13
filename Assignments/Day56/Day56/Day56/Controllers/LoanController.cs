using Day56.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day56.Controllers
{
    public class LoanController : Controller
    {
        private static List<Loan> _loans = [new()
        {
            Id=1,
            LenderName="Ishaan",
            BorrowerName="Bansal",
            Amount=560d,
            IsSettled=true
        },
        new()
        {
            Id=2,
            LenderName="Rakesh",
            BorrowerName="Aman",
            Amount=8900,
            IsSettled=false
        },new()
        {
            Id=3,
            LenderName="Lucy",
            BorrowerName="Nikki",
            Amount=1200,
            IsSettled=true
        }];
        
        
        
        
        // GET: LoanController
        public ActionResult Index()
        {
            return View(model: _loans);
        }

        // GET: LoanController/Details/5
        //public ActionResult Details(int id)
        //{
        //    var x = _loans.Find(i => i.Id == id);
        //    return View(x);
        //}

        // GET: LoanController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoanController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Loan loan)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(loan);
                }
                _loans.Add(loan);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            
        }

        // GET: LoanController/Edit/5
        public ActionResult Edit(int id)
        {
            var x = _loans.Find(x => x.Id == id);
            return View(x);
        }

        // POST: LoanController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Loan loan)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(loan);
                }
                var i = _loans.Find(x => x.Id == id);
                i.BorrowerName = loan.BorrowerName;
                i.LenderName = loan.LenderName;
                i.Amount = loan.Amount;
                i.IsSettled = loan.IsSettled;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoanController/Delete/5
        public ActionResult Delete(int id)
        {
            var x = _loans.Find(x => x.Id == id);
            return View(x);
        }

        // POST: LoanController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,Loan loan)
        {
            var l = _loans.Find(x => x.Id == id);

            if (l != null)
            {
                _loans.Remove(l);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
