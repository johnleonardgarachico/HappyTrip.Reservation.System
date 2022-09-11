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

        public void AddDriver(Driver driverToAdd)
        {
            if (driverToAdd == null)
            {
                throw new ArgumentNullException(nameof(driverToAdd));
            }

            driverToAdd.DriverID = Guid.NewGuid();

            _context.Add(driverToAdd);
        }

        public async Task<Driver> GetDriverAsync(Guid id)
        {
            return (await _context.Drivers.FirstOrDefaultAsync(d => d.DriverID == id))!;
        }

        public async Task<IEnumerable<Driver>> GetDriversAsync()
        {
            return await _context.Drivers.ToListAsync();
        }

        public void RemoveDriver(Driver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(driver));
            }

            _context.Drivers.Remove(driver);
        }

        public void UpdateDriver(Driver driver)
        {
            // Intentionally left blank
            // Update is being done by EntityFramework
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
