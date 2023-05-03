using EventAPP.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventLib.model;

namespace EventAPP.Pages.EventsPages
{
    public class IndexModel : PageModel
    {
        private IEventRepository _service;
        public IndexModel(IEventRepository service)
        {
            _service = service;
        }
        public List<Events> events { get; set; }
        public void OnGet()
        {
            events = _service.GetAll();
        }
    }
}
