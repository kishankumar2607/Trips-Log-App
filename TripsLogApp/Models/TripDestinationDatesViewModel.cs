using System.ComponentModel.DataAnnotations;

namespace TripsLogApp.Models
{
    // ViewModel to capture trip destination and dates information
    public class TripDestinationDatesViewModel
    {
        [Required]
        public string Destination { get; set; }
        public string Accommodation { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
    }
}
