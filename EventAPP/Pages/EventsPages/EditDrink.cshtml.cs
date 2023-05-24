using EventAPP.services;
using EventLib.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics.Tracing;
using System.IO;

namespace EventAPP.Pages.EventsPages
{
    public class EditDrinkModel : PageModel
    {
        private IDrinkRepository _repodrink;
        [BindProperty]
        public Drinks Drink { get; set; }
        [BindProperty]
        public DrinkType Drinktype { get; set; }
        public List<DrinkType> DrinkTypes { get; set; }

        public EditDrinkModel(IDrinkRepository repodrink)
        {
            _repodrink = repodrink;
        }
        public IActionResult OnGet(int id)
        {
            Drink = _repodrink.GetDrinkById(id);
            DrinkTypes = Enum.GetValues<DrinkType>().ToList();
            return Page();

        }
        public IActionResult OnPost(int id, Drinks drink)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            drink.Drinktype = Drinktype;
            _repodrink.UpdateDrinks(id,drink);
            return RedirectToPage("DrinkIndex");
        }
    }
}
