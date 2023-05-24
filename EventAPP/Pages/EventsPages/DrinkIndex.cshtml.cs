using EventAPP.services;
using EventLib.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventAPP.Pages.EventsPages
{
    public class DrinkIndexModel : PageModel
    {
        private IDrinkRepository _drinkrepo;
        private IUserRepository _userRepository;

        public DrinkIndexModel(IDrinkRepository drinkrepo)
        {
            _drinkrepo= drinkrepo;
        }
        public bool IsAdmin { get; set; }
        public List<Drinks> alledrinks { get; set; }
        public void OnGet()
        {
            alledrinks = _drinkrepo.GetAllDrinks();
            _userRepository = SessionHelper.GetUser(HttpContext);
            IsAdmin = _userRepository.IsUserAdmin;
        }
    }
}
