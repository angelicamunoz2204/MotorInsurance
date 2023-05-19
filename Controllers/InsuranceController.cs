using Microsoft.AspNetCore.Mvc;
using MotorInsurance.Models;
using MotorInsurance.Services.Insurances;

namespace motorInsurance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsuranceController : ControllerBase
    {
        private readonly IInsurancesService _service;

        public InsuranceController(IInsurancesService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string insuranceId)
        {
            var insurance = await _service.GetById(insuranceId);
            if(insurance == null)
            {
                return NotFound();
            }

            return Ok(insurance);  
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var insurances = await _service.GetAll(); 
            return this.Ok(insurances);    
        }

        [HttpPost]
        public async Task<IActionResult> Create(Insurance insurance)
        {
            await _service.Create(insurance);
            return CreatedAtAction(nameof(GetById), new { id = insurance.InsuranceID }, insurance);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string insuranceId)
        {
            var insurance = await _service.GetById(insuranceId);
            if(insurance == null)
            {
                return NotFound();
            }

            await _service.Delete(insuranceId);
            return Ok($"insurance type with id {insuranceId} was deleted.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(Insurance insurance)
        {
            var insuranceU = await _service.GetById(insurance.InsuranceID);

            if(insuranceU == null)
            {
                return NotFound();
            }

            await _service.Update(insurance);
            return Ok($"insurance with id {insurance.InsuranceID} was updated.");
        }
    }
}