using EventMiWorkshopMVC.Data;
using EventMiWorkshopMVC.Data.Models;
using EventMiWorkshopMVC.Services.Data.Interfaces;
using EventMiWorkshopMVC.Web.ViewModels.Event;
using Microsoft.EntityFrameworkCore;

namespace EventMiWorkshopMVC.Services.Data
{
    public class EventService : IEventService
    {
        private readonly EventMiDbContext dbContext;

        public EventService(EventMiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task AddEvent(AddEventFromModel model)
        {
            Event newEvent = new Event()
            {
                Name = model.Name,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                Place = model.Place
            };


            await dbContext.Events.AddAsync(newEvent);
            await dbContext.SaveChangesAsync();
        }

        public async Task<EditEventFromModel> GetEventById(int id)
        {
            var eventSearch = await dbContext.Events
                .Where(e => e.Id == id)
                .Select(e => new EditEventFromModel()
                {
                    Name = e.Name,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    Place = e.Place
                }).FirstAsync();

            return eventSearch;
        }

        public async Task EditEventById(int id, EditEventFromModel model)
        {
            var eventToEdit = await dbContext.Events
                .FirstAsync(e => e.Id == id);

            eventToEdit.Name = model.Name;
            eventToEdit.StartDate = model.StartDate;
            eventToEdit.EndDate = model.EndDate;
            eventToEdit.Place = model.Place;

            await dbContext.SaveChangesAsync();
        }
    }
}
