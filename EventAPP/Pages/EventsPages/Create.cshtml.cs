using EventAPP.services;
using EventLib.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EventAPP.Pages.EventsPages
{
    public class CreateModel : PageModel
    {
        private IEventRepository _service;
        public CreateModel (IEventRepository service)
        {
            _service = service;
        }
        [BindProperty]
        [Required(ErrorMessage ="Must have an id ")]
        [Range (0,int.MaxValue, ErrorMessage = "Must not be negative")]
        public int Id { get; set; }
        [BindProperty]
        [Required(ErrorMessage ="Missing a name")]
        [StringLength (100,MinimumLength =2,ErrorMessage = "The name must be between 2 and 100 letters")]
        public string Name { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public DateTime Date { get; set; }
        [BindProperty]
        public EventType EventSlags { get; set; }
        public List<EventType> EventsTyper { get; set; }

        public void OnGet()
        {
            EventsTyper = Enum.GetValues<EventType>().ToList();
        }
        public IActionResult OnPost ()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            
           
            Events ev = new Events(Id,Name,Description,Date,EventSlags);
            _service.Create(ev);
            return RedirectToPage("Index");
        }
    }
}
