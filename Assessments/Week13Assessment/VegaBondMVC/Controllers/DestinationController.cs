using Microsoft.AspNetCore.Mvc;
using VegaBondMVC.Service;
using VagaBondAPI.Models;

namespace VegaBondMVC.Controllers
{
    public class DestinationController : Controller
    {
        private readonly DestinationServices _destinationService;

        public DestinationController(DestinationServices destinationService)
        {
            _destinationService = destinationService;
        }

        public async Task<IActionResult> Index()
        {
            var destinations = await _destinationService.GetAllAsync();
            return View(destinations);
        }

        public async Task<IActionResult> Details(int id)
        {
            var destination = await _destinationService.GetByIdAsync(id);
            if (destination == null) return NotFound();
            return View(destination);
        }
    }
}
