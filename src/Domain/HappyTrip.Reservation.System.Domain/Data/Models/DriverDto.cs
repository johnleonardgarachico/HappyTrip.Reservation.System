using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Reservation.System.Domain.Data.Models
{
    public class DriverDto
    {
        public string Name { get; set; } = default!;
        public string LicenseID { get; set; } = default!;
        public int Age { get; set; }
    }
}
