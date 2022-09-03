using HappyTrip.Reservation.System.Domain.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Reservation.System.Domain.Data.Entities
{
    [Table("Buses")]
    public class Bus
    {
        [Key, MaxLength(6)]
        public string BusNumber { get; set; }
        [Required, MaxLength(30)]
        public string Company { get; set; }
        [Required]
        public Guid DriverID { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Capacity { get; set; }
        [Required]
        public int Lid { get; set; }
        [Required]
        public BusTypeEnum BusType { get; set; }

        public Bus(string busNumber, string company, Guid driverID, double price, int capacity, int lid, BusTypeEnum busType)
        {
            BusNumber = busNumber ?? throw new ArgumentNullException(nameof(busNumber));
            Company = company ?? throw new ArgumentNullException(nameof(company));
            DriverID = driverID;
            Price = price;
            Capacity = capacity;
            Lid = lid;
            BusType = busType;
        }

        public Bus()
        {

        }
    }
}
