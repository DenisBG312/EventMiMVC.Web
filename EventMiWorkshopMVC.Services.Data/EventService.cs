using EventMiWorkshopMVC.Data;
using EventMiWorkshopMVC.Data.Models;
using EventMiWorkshopMVC.Services.Data.Interfaces;
using EventMiWorkshopMVC.Web.ViewModels.Event;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
            var eventDb = await dbContext.Events
                .FirstOrDefaultAsync(e => e.Id == id);

            if (eventDb == null)
            {
                throw new ArgumentException();
            }

            if (!eventDb.IsActive!.Value)
            {
                throw new InvalidOperationException();
            }

            var eventSearch = new EditEventFromModel()
            {
                Name = eventDb.Name,
                StartDate = eventDb.StartDate,
                EndDate = eventDb.EndDate,
                Place = eventDb.Place
            };

            return eventSearch;
        }

        public async Task EditEventById(int id, EditEventFromModel model)
        {
            var eventToEdit = await dbContext.Events
            .FirstAsync(e => e.Id == id);

            if (!eventToEdit.IsActive!.Value)
            {
                throw new InvalidOperationException();
            }

            eventToEdit.Name = model.Name;
            eventToEdit.StartDate = model.StartDate;
            eventToEdit.EndDate = model.EndDate;
            eventToEdit.Place = model.Place;

            await dbContext.SaveChangesAsync();
        }

        public async Task DeleteEventById(int id)
        {
            var eventToDelete = await dbContext.Events.FirstOrDefaultAsync(e => e.Id == id);

            if (eventToDelete == null)
            {
                throw new ArgumentException();
            }

            if (!eventToDelete.IsActive!.Value)
            {
                throw new InvalidOperationException();
            }

            eventToDelete.IsActive = false;
            await dbContext.SaveChangesAsync();
        }
    }
}
