using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VoltGearSystem.Models;
using VoltGearSystem.Service;

namespace VoltGearSystem.Pages.Laptops
{
    public class IndexModel : PageModel
    {
        private LaptopService _service;

        public IndexModel(LaptopService service)
        {
            _service = service;
        }
        [BindProperty]
        public List<Laptop> Laptops { get; set; } = new();

        public async Task OnGetAsync()
        {
            var data = await _service.GetAsync();
            Laptops = data.ToList();
        }
    }
}
