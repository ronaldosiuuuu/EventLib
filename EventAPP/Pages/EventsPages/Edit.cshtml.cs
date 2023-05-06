using EventAPP.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventLib;
using EventLib.model;
using System.Diagnostics.Tracing;

namespace EventAPP.Pages.EventsPages
{
    public class EditModel : PageModel
    {
        private IEventRepository _service;

        public Events Events { get; set; }


        public EditModel(IEventRepository service)
        {
            _service = service;
        }

        public IActionResult OnPostEdit(int id )
        {
            Events = _service.GetById(id);
            return Page();
        }
        //public IActionResult OnPost()
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return Page();
        //    }
        //    _service.Update(Events);
        //    return RedirectToPage("Index");
        //}

    }
}
