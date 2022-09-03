using HappyTrip.Reservation.System.Domain.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Reservation.System.Repository.Interfaces
{
    public interface IHappyTripContext
    {
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<StopOver> StopOvers { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<Trip> Trips { get; set; }
    }
}
