using EventManagementSystem.BLL;
using EventManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
namespace EventManagementSystem.Controllers
{
    [Authorize]
    public class AttendeeController : Controller
    {
        private readonly AttendeeService _attendeeService;

        public AttendeeController(AttendeeService attendeeService)
        {
            _attendeeService = attendeeService;
        }

        public IActionResult Index()
        {
            var attendees = _attendeeService.GetAll();
            return View(attendees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Attendee attd)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "An error occurred while saving the attendee");
                return View(attd);
            }
            try
            {
                _attendeeService.Add(attd);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.Message.Contains("UNIQUE"))
                    ModelState.AddModelError("", "Email already exists");
                else
                    ModelState.AddModelError("", "An error occurred while saving the attendee");
                return View(attd);
            }
        }

        public IActionResult Edit(int id)
        {
            var attendee = _attendeeService.Get(id);
            if (attendee == null)
                return RedirectToAction("Index");
            return View(attendee);
        }

        [HttpPost]
        public IActionResult Edit(Attendee attd)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "An error occurred while saving the attendee");
                return View(attd);
            }
            try
            {
                _attendeeService.Update(attd);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // Check if the exception is due to a duplicate email
                if (ex.InnerException != null && ex.InnerException.Message.Contains("UNIQUE"))
                    ModelState.AddModelError("", "Email already exists");
                else
                    ModelState.AddModelError("", "An error occurred while saving the attendee");
                return View(attd);
            }
        }

        public IActionResult Delete(int id)
        {
            var attd = _attendeeService.Get(id);
            if (attd == null)
                return RedirectToAction("Index");
            _attendeeService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}