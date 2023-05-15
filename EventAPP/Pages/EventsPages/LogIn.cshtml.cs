using EventAPP.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EventAPP.Pages.EventsPages
{
    public class LogInModel : PageModel
    {

        private IUserRepository _userRepository;

        public LogInModel()
        {
        }
        [BindProperty]
        [Required]
        [StringLength(50, MinimumLength =5, ErrorMessage = "Please enter your Email")]
        public string Email { get; set; }
        [BindProperty]
        [Required]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "Please enter your password"), DataType(DataType.Password)]
        public string Password { get; set; }
        public void OnGet()
        {
            _userRepository = SessionHelper.GetUser(HttpContext); 
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (Password != Password)
            {
                return Page();
            }
            if(Email == "Admin123@ZealandZoo.dk" && Password == "zealandzoo")
            {
                _userRepository.SetUserLoggedIn(Email, true);
            }
            else
            {
                _userRepository.SetUserLoggedIn(Email, false);
            }


            SessionHelper.SetUser(_userRepository, HttpContext);
            return RedirectToPage("Index");


        }




    }
}
