using AutoMapper;
using HappyTrip.Reservation.System.Controller.Filters;
using HappyTrip.Reservation.System.Domain;
using HappyTrip.Reservation.System.Domain.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HappyTrip.Reservation.System.Controller
{
    [ApiController]
    [Route("api")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper; 

        public DriverController(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository ?? throw new ArgumentNullException(nameof(driverRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("drivers")]
        public async Task<IActionResult> GetDrivers()
        {
            var driversEntity = await _driverRepository.GetDriversAsync();

            if (driversEntity is null)
            {
                return NotFound();
            }

            var driversDto = _mapper.Map<IEnumerable<Driver>>(driversEntity);

            return Ok(driversDto);
        }
    }
}