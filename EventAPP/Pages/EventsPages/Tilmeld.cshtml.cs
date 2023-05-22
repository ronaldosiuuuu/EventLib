using EventAPP.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventAPP.Pages.EventsPages
{
    public class TilmeldModel : PageModel
    {
        public TilmeldModel(IUserRepository service,IEventRepository Eservices)
        {
            _userRepository = service;
            _eventrepo = Eservices;
        }
        private IEventRepository _eventrepo;
        private IUserRepository _userRepository;
        [BindProperty]
        public int ID { get; set; }
        [BindProperty]
        public string UserName { get; set; }


        public void OnGet(int id)
        {
            ID = id;
            _userRepository = SessionHelper.GetUser(HttpContext);
            UserName = _userRepository.UserName;

        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();

            }
            _eventrepo


            return Page();
        }
    }
}
