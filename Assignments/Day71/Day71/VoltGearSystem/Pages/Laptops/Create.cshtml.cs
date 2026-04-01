using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VoltGearSystem.Models;
using VoltGearSystem.Service;

namespace VoltGearSystem.Pages.Laptops
{
    public class CreateModel : PageModel
    {

        private LaptopService _service;

        public CreateModel(LaptopService service)
        {
            _service = service;
        }
        [BindProperty]
        public Laptop Laptop { get; set; } = new Laptop();
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync()
        {

            foreach (var state in ModelState)
            {
                foreach (var error in state.Value.Errors)
                {
                    Console.WriteLine($"{state.Key}: {error.ErrorMessage}");
                }
            }

            if (!ModelState.IsValid)
                return Page();

            await _service.CreateAsync(Laptop);

            TempData["SuccessMessage"] = "Laptop successfully saved to MongoDB";
            ModelState.Clear();

            return RedirectToPage("Index");
        }
    }
}
