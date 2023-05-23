using EventAPP.services;
using EventLib.model;
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
            _userRepository = SessionHelper.GetUser(HttpContext);
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(!_userRepository.TjekLogInd(Email, Password))
            {
                return Page();
            }

            SessionHelper.SetUser(_userRepository, HttpContext);
            return RedirectToPage("Index");


        }




    }
}
