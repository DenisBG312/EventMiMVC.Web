using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventMiWorkshopMVC.Data.Models;
using EventMiWorkshopMVC.Web.ViewModels.Event;

namespace EventMiWorkshopMVC.Services.Data.Interfaces
{
    public interface IEventService
    {
        Task AddEvent(AddEventFromModel model);
        Task<EditEventFromModel> GetEventById (int id);
        Task EditEventById(int id, EditEventFromModel model);
        Task DeleteEventById(int id);
        Task<List<Event>> GetAllEventsAsync();

        Task<Event> GetEventDetailsAsync(int id);
    }
}
