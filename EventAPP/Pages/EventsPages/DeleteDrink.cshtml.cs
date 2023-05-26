using EventAPP.services;
using EventLib.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventAPP.Pages.EventsPages
{
    public class DeleteDrinkModel : PageModel
    {
        private IDrinkRepository _reposdrink;
        public DeleteDrinkModel(IDrinkRepository reposdrink)
        {
            _reposdrink = reposdrink;
        }
        public Drinks Drink { get; set; }
        public void OnGet(int id)
        {
            Drink = _reposdrink.DeleteDrinks(id);
        }
        public IActionResult OnPostDeleter(int id)
        {
            _reposdrink.DeleteDrinks(id);
            return RedirectToPage("DrinkIndex");
        }

        public IActionResult OnPosttilbage()
        {
            return RedirectToPage("DrinkIndex");
        }
    }
}
