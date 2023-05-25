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
        private ITilmeld _tilmeldrepo;
        
        public bool IsAdmin { get; set; }

        public IndexModel(IEventRepository service, ITilmeld tilmeldrepo)
        {
            _service = service;
            _tilmeldrepo = tilmeldrepo;
        }
        public List<Events> kommendeevents { get; set; }
        public void OnGet()
        {
            kommendeevents = _service.GetAll();
            _userRepository = SessionHelper.GetUser(HttpContext);
            IsAdmin = _userRepository.IsUserAdmin;
            
        }
        public int GetAntal(int id)
        {
            return _tilmeldrepo.AntalTilmeldte(id);
        }
    }
}
