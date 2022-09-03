using HappyTrip.Reservation.System.Domain.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyTrip.Reservation.System.Domain
{
    public interface IDriverRepository
    {
        public Task<IEnumerable<Driver>> GetDriversAsync();
    }
}
