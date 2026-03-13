using System.Diagnostics;
using Day55.Models;
using Microsoft.AspNetCore.Mvc;

namespace Day55.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            List<Employee> emps = new List<Employee>()
            {
                new Employee()
                {
                    Id=1,
                    Name="Raj",
                    Position="CFO",
                    Salary=15000
                },
                new Employee()
                {
                    Id=2,
                    Name="Rahul",
                    Position="CEO",
                    Salary=20000
                },
                new Employee()
                {
                    Id=3,
                    Name="Rakesh",
                    Position="CTO",
                    Salary=18000
                }
            };

            var announcement = "Check Below for Employee Details";
            ViewBag.announcement = announcement;

            var dept = "IT";
            ViewData["dept"] = dept;

            var status = "Active";
            ViewData["status"] = status;

            return View(model: emps);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
