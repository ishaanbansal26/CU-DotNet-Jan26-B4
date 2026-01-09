using Microsoft.AspNetCore.Mvc;

namespace TrainingPortal.Controllers
{
    public class Training : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }
    }
}
