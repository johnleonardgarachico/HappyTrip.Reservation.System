using HappyTrip.Reservation.System.Domain;
using HappyTrip.Reservation.System.Domain.Data.Entities;
using HappyTrip.Reservation.System.Repository.DatabaseContext;
using HappyTrip.Reservation.System.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Reservation.System.Repository.Repository
{
    public class DriverRepository : IDriverRepository
    {
        private readonly HappyTripContext _context;

        public DriverRepository(HappyTripContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Driver>> GetDriversAsync()
        {
            return await _context.Drivers.ToListAsync();
        }
    }
}
