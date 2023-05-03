using EventAPP.services;
using EventLib.model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EventAPP.Pages.EventsPages
{
    public class CreateModel : PageModel
    {
        private IEventRepository service;
        public CreateModel (IEventRepository repo)
        {
            service = repo;
        }
        [BindProperty]
        [Required(ErrorMessage ="Der skal være et ID ")]
        [Range (0,int.MaxValue, ErrorMessage ="Må ikke være negativ ")]
        public int Id { get; set; }
        [BindProperty]
        [Required(ErrorMessage ="Mangler et navn")]
        [StringLength (100,MinimumLength =5,ErrorMessage ="Navnet skal være mellem 5 til 100 bogstaver")]
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
            service.Create(ev);
            return RedirectToPage("Index");
        }
    }
}
