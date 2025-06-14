using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripsLogApp.Models;

namespace TripsLogApp.Controllers
{
    public class TripController : Controller
    {
        // Database context to manage trips
        private TripContext context { get; set; }

        // Constructor to inject TripContext
        public TripController(TripContext ctx)
        {
            context = ctx;
        }

        // GET: Show first form to add trip destination and dates
        [HttpGet]
        public IActionResult Add()
        {
            return View(new TripDestinationDatesViewModel());
        }

        // POST: Handle submission of destination and dates form
        [HttpPost]
        public IActionResult Add(TripDestinationDatesViewModel model)
        {
            var errors = new List<string>();

            // Basic validation of required fields
            if (string.IsNullOrWhiteSpace(model.Destination))
                errors.Add("Destination is required.");
            if (!model.StartDate.HasValue)
                errors.Add("Start Date is required.");
            if (!model.EndDate.HasValue)
                errors.Add("End Date is required.");

            // If there are errors, return the view with messages
            if (errors.Any())
            {
                ViewBag.Errors = errors;
                return View(model);
            }

            // Store form values in TempData for later use
            TempData["Destination"] = model.Destination;
            TempData["Accommodation"] = model.Accommodation ?? "";
            TempData["StartDate"] = model.StartDate.ToString();
            TempData["EndDate"] = model.EndDate.ToString();

            // Decide which page to go next based on whether accommodation was entered
            if (string.IsNullOrWhiteSpace(model.Accommodation))
            {
                return RedirectToAction("AddPage3");
            }
            else
            {
                return RedirectToAction("AddPage2");
            }
        }

        // GET: Show second form to enter accommodation contact info
        [HttpGet]
        public IActionResult AddPage2()
        {
            ViewBag.Subhead = TempData["Accommodation"];

            // Keep TempData for next request
            TempData.Keep();
            return View(new TripAccommodationInfoViewModel { Accommodation = TempData["Accommodation"]?.ToString() });
        }

        // POST: Handle submission of accommodation info
        [HttpPost]
        public IActionResult AddPage2(TripAccommodationInfoViewModel model)
        {
            // Store additional contact info
            TempData["AccommodationPhone"] = model.AccommodationPhone;
            TempData["AccommodationEmail"] = model.AccommodationEmail;
            TempData.Keep();
            return RedirectToAction("AddPage3");
        }

        // GET: Show third form to enter things to do on the trip
        [HttpGet]
        public IActionResult AddPage3()
        {
            ViewBag.Subhead = TempData["Destination"];
            TempData.Keep();
            return View(new TripThingsToDoViewModel { Destination = TempData["Destination"]?.ToString() });
        }

        // POST: Final submission - collect all data and save the trip
        [HttpPost]
        public IActionResult AddPage3(TripThingsToDoViewModel model)
        {
            var trip = new Trip
            {
                Destination = TempData["Destination"]?.ToString(),
                Accommodation = TempData["Accommodation"]?.ToString(),
                StartDate = DateTime.Parse(TempData["StartDate"]?.ToString()),
                EndDate = DateTime.Parse(TempData["EndDate"]?.ToString()),
                AccommodationPhone = TempData["AccommodationPhone"]?.ToString(),
                AccommodationEmail = TempData["AccommodationEmail"]?.ToString(),
                ThingToDo1 = model.ThingToDo1,
                ThingToDo2 = model.ThingToDo2,
                ThingToDo3 = model.ThingToDo3,
            };

            // Save the new trip to the database
            context.Trips.Add(trip);
            context.SaveChanges();

            // Clear TempData and show confirmation message
            TempData.Clear();
            TempData["Subhead"] = $"Trip to {trip.Destination} added.";

            // Redirect to Home page index
            return RedirectToAction("Index", "Home");
        }

        // Cancel the process and clear all temporary data
        [HttpPost]
        public IActionResult Cancel()
        {
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
