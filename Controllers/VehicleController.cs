using Microsoft.AspNetCore.Mvc;
using MotorInsurance.Models;
using MotorInsurance.Services.Vehicles;

namespace motorInsurance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehiclesService _service;

        public VehicleController(IVehiclesService service)
        {
            _service = service;
        }

        [HttpGet("{licensePlate}")]
        public async Task<IActionResult> GetByPlate(string licensePlate)
        {
            var vehicle = await _service.GetByPlate(licensePlate);
            if(vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);  
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vehicles = await _service.GetAll(); 
            return this.Ok(vehicles);    
        }

        [HttpPost]
        public async Task<IActionResult> Create(Vehicle vehicle)
        {
            await _service.Create(vehicle);
            return CreatedAtAction(nameof(GetByPlate), new { id = vehicle.LicensePlate}, vehicle);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string licensePlate)
        {
            var vehicle = await _service.GetByPlate(licensePlate);
            if(vehicle == null)
            {
                return NotFound();
            }

            await _service.Delete(licensePlate);
            return Ok($"vehicle type with license plate {licensePlate} was deleted.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(Vehicle vehicle)
        {
            var vehicleU = await _service.GetByPlate(vehicle.LicensePlate);

            if(vehicleU == null)
            {
                return NotFound();
            }

            await _service.Update(vehicle);
            return Ok($"vehicle with license plate {vehicle.LicensePlate} was updated.");
        }
    }
}