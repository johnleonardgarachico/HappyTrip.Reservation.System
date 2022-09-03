using HappyTrip.Reservation.System.Controller.Filters;
using HappyTrip.Reservation.System.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HappyTrip.Reservation.System.Controller
{
    [ApiController]
    [Route("api")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverRepository _driverRepository;

        public DriverController(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository ?? throw new ArgumentNullException(nameof(driverRepository));
        }

        [HttpGet]
        [Route("drivers")]
        [DriversResultFilter]
        public async Task<IActionResult> GetDrivers()
        {
            var driversEntity = await _driverRepository.GetDriversAsync();
            return Ok(driversEntity);
        }
    }
}