using EventAPP.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventAPP.Pages.EventsPages
{
    public class LogOutModel : PageModel
    {
        private IUserRepository _userRepository;

        public LogOutModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    
        public IActionResult OnGet()
        {
            _userRepository = SessionHelper.GetUser(HttpContext);
            _userRepository.UserLoggedOut();
            SessionHelper.SetUser(_userRepository, HttpContext);

            return RedirectToPage("Index");
        }
    }
}
