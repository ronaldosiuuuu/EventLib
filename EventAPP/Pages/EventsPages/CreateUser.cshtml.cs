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
        public List<User> Users { get; set; }
        public void OnGet()
        {
            Users = _userRepository.GetAllUsers();
            IsAdmin = false;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Users = _userRepository.GetAllUsers();
                return Page();
            }
            User us = new User
            {
                Email = Email,
                IsAdmin = IsAdmin,
                Password = Password
            };

            _userRepository.CreateUser(us);
            return RedirectToPage("UserIndex");

        }
    }
}
