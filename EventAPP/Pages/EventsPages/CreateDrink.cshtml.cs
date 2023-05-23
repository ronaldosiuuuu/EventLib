using EventAPP.services;
using EventLib.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventAPP.Pages.EventsPages
{
    public class CreateDrinkModel : PageModel
    {
        private IDrinkRepository _repository;

        public CreateDrinkModel(IDrinkRepository repository)
        {
            _repository = repository;
        }
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public double Price { get; set; }
        [BindProperty]
        public int Quanity { get; set; }
        [BindProperty]
        public DrinkType Drinktype { get; set; }
        public List<DrinkType> DrinkTypes { get; set; }

        public void OnGet()
        {
        DrinkTypes = Enum.GetValues<DrinkType>().ToList();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Drinks drinks = new Drinks(Id, Drinktype, Name, Price, Quanity );
            _repository.CreateDrinks( drinks );
            return RedirectToPage("DrinkIndex");
        }
    }
}
