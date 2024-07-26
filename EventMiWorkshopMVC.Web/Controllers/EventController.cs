using EventMiWorkshopMVC.Data.Models;
using EventMiWorkshopMVC.Services.Data;
using EventMiWorkshopMVC.Services.Data.Interfaces;
using EventMiWorkshopMVC.Web.ViewModels.Event;
using Microsoft.AspNetCore.Mvc;

namespace EventMiWorkshopMVC.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventService eventService;

        public EventController(IEventService eventService)
        {
            this.eventService = eventService;
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddEventFromModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.StartDate > model.EndDate)
            {
                ModelState.AddModelError(nameof(model.StartDate), "Start Date cannot be after End Date!");
                return View(model);
            }

            await eventService.AddEvent(model);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                var formModel = await eventService.GetEventById(id.Value);

                return View(formModel);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, EditEventFromModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                await eventService.EditEventById(id.Value, model);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                var formModel = await eventService.GetEventById(id.Value);

                return View(formModel);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, EditEventFromModel model)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                await eventService.DeleteEventById(id.Value);

                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        public async Task<IActionResult> All()
        {
            var events = await eventService.GetAllEventsAsync();
            return View(events);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }

            try
            {
                Event model = await eventService.GetEventDetailsAsync(id.Value);

                return View(model);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index", "Home");
            }
        }


    }
}
