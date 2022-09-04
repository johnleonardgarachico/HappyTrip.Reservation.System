using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Reservation.System.Domain.Data.Models
{
    public class DriverForCreation
    {
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
    }
}
