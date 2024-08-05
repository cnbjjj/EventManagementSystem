using EventManagementSystem.BLL;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace EventManagementSystem.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Index()
        {
            var events = _eventService.GetAll();
            return View(events);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event evt)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "An error occurred while creating the event");
                return View(evt);
            }
            _eventService.Add(evt);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var evt = _eventService.Get(id);
            if (evt == null)
                return RedirectToAction("Index");
            return View(evt);
        }

        [HttpPost]
        public IActionResult Edit(Event evt)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "An error occurred while saving the event");
                return View(evt);
            }
            _eventService.Update(evt);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var evt = _eventService.Get(id);
            if (evt == null)
                return RedirectToAction("Index");
            _eventService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}