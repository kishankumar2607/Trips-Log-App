using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripsLogApp.Models;

namespace TripsLogApp.Controllers
{
    public class HomeController : Controller
    {
        // Database context to access Trip data
        private TripContext context { get; set; }

        // Constructor to inject the TripContext
        public HomeController(TripContext ctx)
        {
            context = ctx;
        }

        // Main action to list all trips
        public IActionResult Index()
        {
            // Retrieve any temporary message stored in TempData for subheading
            ViewBag.Subhead = TempData["Subhead"];
            var trips = context.Trips.ToList();
            return View(trips);
        }

        // Privacy page action
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
