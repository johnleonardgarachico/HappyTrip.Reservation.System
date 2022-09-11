using AutoMapper;
using HappyTrip.Reservation.System.Domain;
using HappyTrip.Reservation.System.Domain.Data.Models;
using HappyTrip.Reservation.System.Domain.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

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

            if (driverEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<DriverDto>(driverEntity));
        }

        [HttpGet("drivers")]
        public async Task<IActionResult> GetDrivers()
        {
            var driversEntity = await _driverRepository.GetDriversAsync();

            if (driversEntity == null)
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

        [HttpDelete("driver/{id}")]
        public async Task<IActionResult> DeleteDriver(Guid id)
        {
            var driverFromRepo = await _driverRepository.GetDriverAsync(id);

            if (driverFromRepo == null)
            {
                return NotFound();
            }

            _driverRepository.RemoveDriver(driverFromRepo);
            await _driverRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("driver/{id}")]
        public async Task<IActionResult> UpdateDriver(Guid id, JsonPatchDocument<DriverForUpdateDto> patchDocument)
        {
            var driverFromRepo = await _driverRepository.GetDriverAsync(id);

            // Create driver if does not exists
            if (driverFromRepo == null)
            {
                var driverDto = new DriverForUpdateDto();
                patchDocument.ApplyTo(driverDto, ModelState);

                if (!TryValidateModel(driverDto))
                {
                    return ValidationProblem(ModelState);
                }

                var driverToAdd = _mapper.Map<Driver>(driverDto);

                return CreatedAtRoute("GetDriver", new { id = driverToAdd.DriverID }, driverToAdd);
            }

            var driverToPatch = _mapper.Map<DriverForUpdateDto>(driverFromRepo);

            patchDocument.ApplyTo(driverToPatch, ModelState);

            if (!TryValidateModel(driverToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(driverToPatch, driverFromRepo);

            _driverRepository.UpdateDriver(driverFromRepo);

            await _driverRepository.SaveChangesAsync();

            return NoContent();
        }

        public override ActionResult ValidationProblem([ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices.GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}