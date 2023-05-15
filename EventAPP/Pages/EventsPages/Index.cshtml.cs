using EventAPP.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventLib.model;

namespace EventAPP.Pages.EventsPages
{
    public class IndexModel : PageModel
    {
        private IEventRepository _service;
        private IUserRepository _userRepository;

        public IndexModel(IEventRepository service, IUserRepository userRepository)
        {
            _service = service;
            _userRepository = userRepository;
        }

        public bool IsAdmin
        {
            get
            {
                return _userRepository.IsUserAdmin;
            }
        }

        public string Email
        {
            get
            {
                return _userRepository.UserName;
            }
        }
        public IActionResult OnGetLogin()
        {
            _userRepository = SessionHelper.GetUser(HttpContext);
            if (!_userRepository.IsLoggedIn)
            {
                return RedirectToPage("Index");
            }
            return Page();
        }
        
        public List<Events> kommendeevents { get; set; }
        public void OnGet()
        {
            kommendeevents = _service.GetAll();
        }
    }
}
