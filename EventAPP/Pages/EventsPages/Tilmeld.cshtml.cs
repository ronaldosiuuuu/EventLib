using EventAPP.services;
using EventLib.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EventAPP.Pages.EventsPages
{
    public class TilmeldModel : PageModel
    {
        // we inject the service trough the constructer 
        public TilmeldModel(IUserRepository service, IEventRepository Eservices, ITilmeld tilmeldrepo)
        {
            _userRepository = service;
            _eventrepo = Eservices;
            _tilmeldRepo = tilmeldrepo;
        }
        private IEventRepository _eventrepo;
        private IUserRepository _userRepository;
        private ITilmeld _tilmeldRepo;

        [BindProperty]
        public int ID { get; set; }
        [BindProperty]
        public string UserName { get; set; }
        [BindProperty]
        public Tilmeld Tilmeld { get; set; }

        public int MaxTilmeld { get; set; }
        [BindProperty]
        public List<User> Tilmeldte { get; set; }


        public void OnGet(int id)
        {
            MaxTilmeld = _eventrepo.GetById(id).MaxTilmeld;
            ID = id;
            _userRepository = SessionHelper.GetUser(HttpContext);
            UserName = _userRepository.UserName;

        }
        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();

            }
            MaxTilmeld = _eventrepo.GetById(id).MaxTilmeld;
            if (_tilmeldRepo.AntalTilmeldte(ID) + 1 <= MaxTilmeld)
            {
                Tilmeld tilmeld = new Tilmeld(UserName, ID);

                _tilmeldRepo.CreateTilmeld(tilmeld);

            }
            else
            {
                return RedirectToPage("Index");
            }

            //Tilmeld tilmeld = new Tilmeld(UserName, ID);

            //_tilmeldRepo.CreateTilmeld(tilmeld);


            return RedirectToPage("Index");
        }
    }
}
