using EventAPP.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventLib;
using EventLib.model;

namespace EventAPP.Pages.EventsPages
{
    public class DeleteModel : PageModel
    {
        private IEventRepository _service;

        public DeleteModel(IEventRepository service)
        {
            _service = service; 
        }

        public Events Events { get; set; }
        
        public void OnGet(int id)
        {
            Events = _service.GetById(id);
        }

        public IActionResult OnPostDelete(int id)
        {
            _service.Delete(id);
            return RedirectToPage("Index");
        }

        public IActionResult OnPostRegret()
        {
            return RedirectToPage("Index");
        }
    }
}
