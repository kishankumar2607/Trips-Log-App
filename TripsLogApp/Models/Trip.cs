﻿namespace TripsLogApp.Models
{
    // This class represents a travel trip with related details
    public class Trip
    {
        public int TripId { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Accommodation { get; set; }
        public string? AccommodationPhone { get; set; }
        public string? AccommodationEmail { get; set; }
        public string? ThingToDo1 { get; set; }
        public string? ThingToDo2 { get; set; }
        public string? ThingToDo3 { get; set; }
    }

}
