using EventAPP.services;
using EventLib.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventAPP.Pages.EventsPages
{
    public class DrinkIndexModel : PageModel
    {
        private IDrinkRepository _drinkrepo;

        public DrinkIndexModel(IDrinkRepository drinkrepo)
        {
            _drinkrepo= drinkrepo;
        }
        public List<Drinks> alledrinks { get; set; }
        public void OnGet()
        {
            alledrinks = _drinkrepo.GetAllDrinks();
        }
    }
}
