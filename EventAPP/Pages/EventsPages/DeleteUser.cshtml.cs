using EventAPP.services;
using EventLib.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventAPP.Pages.EventsPages
{
    public class DeleteUserModel : PageModel
    {
        private IUserRepository _userRepository;

        public DeleteUserModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public User user { get; set; }
        public void OnGet(string email)
        {
            user = _userRepository.GetUserByEmail(email);
        }
        public IActionResult OnPostDeleteUser(string email)
        {
            _userRepository.DeleteUser(email);
            return RedirectToPage("UserIndex");
        }
    }
}
