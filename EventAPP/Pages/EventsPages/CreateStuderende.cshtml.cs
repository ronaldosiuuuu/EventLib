using EventAPP.services;
using EventLib.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventAPP.Pages.EventsPages
{
    public class CreateStuderendeModel : PageModel
    {
        private IUserRepository _services;

        public CreateStuderendeModel (IUserRepository services)
        {
            _services = services;
        }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public bool IsAdmin { get; set; }
        [BindProperty]
        public string Password { get; set; }

        public List<User> Users { get; set; }

        public void OnGet()
        {
            Users = _services.GetAllUsers();
        }
        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            User userb = new User(Email,IsAdmin,Password);
            _services.CreateUser(userb);

            return RedirectToPage("Index");

        }
    }
}
