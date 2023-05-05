using EventAPP.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EventLib;
using EventLib.model;

namespace EventAPP.Pages.EventsPages
{
    public class EditModel : PageModel
    {
        private IEventRepository _service;

        public EditModel(IEventRepository service)
        {
            _service = service;
        }
        //public void OnGetEdit(int id)
        //{
        //    Events EditEvents = _service.GetById(id);
        //    Id = EditEvents.Id;
        //    Name = EditEvents.Name;
        //    EventsSlags = EditEvents.EventSlags;
        //    Description = EditEvents.Description;
        //    Date = EditEvents.Date; 
        //}
    }
}
