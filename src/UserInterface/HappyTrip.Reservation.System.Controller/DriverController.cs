using AutoMapper;
using HappyTrip.Reservation.System.Domain;
using HappyTrip.Reservation.System.Domain.Data.Models;
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

        [HttpGet("driver/{id}", Name = "GetDriver")]
        public async Task<IActionResult> GetDriver(Guid id)
        {
            var driverEntity = await _driverRepository.GetDriverAsync(id);

            if (driverEntity is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<DriverDto>>(driverEntity));
        }

        [HttpGet("drivers")]
        public async Task<IActionResult> GetDrivers()
        {
            var driversEntity = await _driverRepository.GetDriversAsync();

            if (driversEntity is null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<IEnumerable<DriverDto>>(driversEntity));
        }

        [HttpPost("driver")]
        public async Task<IActionResult> CreateDriver(DriverForCreation driverForCreation)
        {
            var driverEntity = _mapper.Map<Driver>(driverForCreation);

            _driverRepository.AddDriver(driverEntity);

            await _driverRepository.SaveChangesAsync();

            return CreatedAtRoute("GetDriver", new { id = driverEntity.DriverID }, driverEntity);
        }
    }
}