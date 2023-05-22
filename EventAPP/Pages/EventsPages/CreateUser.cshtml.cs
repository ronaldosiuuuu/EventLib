using EventAPP.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventLib.model;

namespace EventAPP.Pages.EventsPages
{
    public class CreateUserModel : PageModel
    {
        private IUserRepository _userRepository;
        public CreateUserModel(IUserRepository service)
        {
            _userRepository = service;
        }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public bool IsAdmin { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            User us = new User (Email, IsAdmin,Password);
            _userRepository.CreateUser(us);
            return RedirectToPage("UserIndex");
        }
    }
}
