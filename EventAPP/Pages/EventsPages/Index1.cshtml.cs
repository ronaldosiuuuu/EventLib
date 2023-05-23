using EventAPP.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventAPP.Pages.EventsPages
{
    public class Index1Model : PageModel
    {
        private IUserRepository _userRepository;


        public bool IsUserAdmin
        {
            get
            {
                return _userRepository.IsUserAdmin;
            }
        }
        public string Email => _userRepository.UserName;

        public Index1Model()
        {
        }
        public IActionResult OnGet()
        {
            _userRepository = SessionHelper.GetUser(HttpContext);

            if (!_userRepository.IsLoggedIn)
            {
                return RedirectToPage("LogIn");
            }
            return Page();

        }
    }
}
