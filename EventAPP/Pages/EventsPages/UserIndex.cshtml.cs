using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventLib.model;
using EventAPP.services;

namespace EventAPP.Pages.EventsPages
{
    public class UserIndexModel : PageModel
    {
        private IUserRepository _userRepository;
        


        public UserIndexModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [BindProperty]
        public List<User> Users { get; set; }
        public void OnGet()
        {
            Users = _userRepository.GetAllUsers();
            _userRepository = SessionHelper.GetUser(HttpContext);
            if (_userRepository.IsLoggedIn)
            {
                //_userRepository.IsUserAdmin;
                //_userRepository.IsLoggedIn;

            }

        }
    }
}
