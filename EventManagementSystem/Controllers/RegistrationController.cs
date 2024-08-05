using EventManagementSystem.BLL;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace EventManagementSystem.Controllers
{
    [Authorize]
    public class RegistrationController : Controller
    {
        private readonly RegistrationService _registrationService;
        private readonly AttendeeService _attendeeService;
        private readonly EventService _eventService;
        public RegistrationController(RegistrationService registrationService, AttendeeService attendeeService, EventService eventService)
        {
            _registrationService = registrationService;
            _attendeeService = attendeeService;
            _eventService = eventService;
        }

        [HttpGet("")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            var regs = _registrationService.GetAll();
            return View(regs);
        }

        public IActionResult Create()
        {
            SetViewBags();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Registration reg)
        {
            if (!ModelState.IsValid)
                return ErrorView(reg, "An error occurred while creating the registration.");
            if (IsDuplicate(reg))
                return ErrorView(reg, "A registration for this event and attendee already exists.");
            _registrationService.Add(reg);
            return RedirectToAction("Index");
        }
        
        public IActionResult Edit(int id)
        {
            var reg = _registrationService.Get(id);
            if(reg == null)
                return RedirectToAction("Index");
            SetViewBags();
            return View(reg);
        }

        [HttpPost]
        public IActionResult Edit(Registration reg)
        {
            if (!ModelState.IsValid)
                return ErrorView(reg, "An error occurred while saving the registration.");
            if (IsDuplicate(reg))
                return ErrorView(reg, "A registration for this event and attendee already exists.");
            _registrationService.Update(reg);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var reg = _registrationService.Get(id);
            if (reg == null)
                return RedirectToAction("Index");
            _registrationService.Remove(id);
            return RedirectToAction("Index");
        }

        // ErrorView method is used to display error messages on the view when an error occurs.
        private IActionResult ErrorView(Registration reg, string  message="Unknown Error Occured.")
        {
            ModelState.AddModelError("", message);
            SetViewBags();
            return View(reg);
        }

        // Before interacting with the database, this method is called to check if the registration already exists.
        private bool IsDuplicate(Registration reg)
        {
            return _registrationService.GetAll()
            .Any(r => r.EventId == reg.EventId && r.AttendeeId == reg.AttendeeId && r.RegistrationId != reg.RegistrationId);
        }

        // Set the ViewBag properties for the view.
        private void SetViewBags()
        {
            ViewBag.Attendees = _attendeeService.GetAll();
            ViewBag.Events = _eventService.GetAll();
        }
    }
}