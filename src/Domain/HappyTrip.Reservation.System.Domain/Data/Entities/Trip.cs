using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HappyTrip.Reservation.System.Domain.Data.Entities
{
    [Table("Trips")]
    public class Trip
    {
        [Key]
        public Guid TripID { get; set; }
        [Required, MaxLength(6)]
        public string BusNumber { get; set; }
        [Required, MaxLength(20)]
        public string Origin { get; set; }
        [Required, MaxLength(20)]
        public string Destination { get; set; }
        [Required]
        public DateTime Departure { get; set; }
        [Required]
        public DateTime Arrival { get; set; }

        public Trip(Guid tripID, string busNumber, string origin, string destination, DateTime departure, DateTime arrival)
        {
            TripID = tripID;
            BusNumber = busNumber ?? throw new ArgumentNullException(nameof(busNumber));
            Origin = origin ?? throw new ArgumentNullException(nameof(origin));
            Destination = destination ?? throw new ArgumentNullException(nameof(destination));
            Departure = departure;
            Arrival = arrival;
        }

        public Trip()
        {

        }
    }
}
