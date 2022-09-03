using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Reservation.System.Domain.Data.Entities
{
    [Table("Drivers")]
    public class Driver
    {
        [Key]
        public Guid DriverID { get; set; }
        [Required, MaxLength(20)]
        public string FirstName { get; set; } = default!;
        [MaxLength(20)]
        public string MiddleName { get; set; } = default!;
        [Required, MaxLength(20)]
        public string LastName { get; set; } = default!;
        [Required]
        public string LicenseID { get; set; } = default!;
        [Required]
        public DateTime BirthDate { get; set; }

        /*public Driver(Guid driverID, string firstName, string lastName, string licenseID, DateTime birthDate, string middleName = "")
        {
            DriverID = driverID;
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            MiddleName = middleName ?? throw new ArgumentNullException(nameof(middleName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
            LicenseID = licenseID ?? throw new ArgumentNullException(nameof(licenseID));
        }

        public Driver()
        {

        }*/
    }
}
