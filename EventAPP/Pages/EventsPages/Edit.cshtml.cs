using EventAPP.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventLib;
using EventLib.model;
using System.Diagnostics.Tracing;
using System.ComponentModel.DataAnnotations;

namespace EventAPP.Pages.EventsPages
{
    public class EditModel : PageModel
    {
        private IEventRepository _service;

        [BindProperty]
        public Events Events { get; set; }
        [BindProperty]
        public EventType EventSlags { get; set; }
        public List<EventType> EventsTyper { get; set; }


        public EditModel(IEventRepository service)
        {
            _service = service;
        }



        public IActionResult OnGet(int id)
        {
            Events = _service.GetById(id);
            EventsTyper = Enum.GetValues<EventType>().ToList();
            return Page();

        }
        public IActionResult OnPost(int id, Events events)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            events.EventSlags = EventSlags;
            _service.Update(id,events);
            return RedirectToPage("Index");
        }

    }
}
