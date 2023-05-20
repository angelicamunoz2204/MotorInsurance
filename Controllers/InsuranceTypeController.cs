using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MotorInsurance.Models;
using MotorInsurance.Services.InsuranceTypes;

namespace motorInsurance.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class InsuranceTypeController : ControllerBase
    {
        private readonly IInsuranceTypesService _service;

        public InsuranceTypeController(IInsuranceTypesService service)
        {
            _service = service;
        }

        [HttpGet("{insuranceTypeId}")]
        public async Task<IActionResult> GetById(string insuranceTypeId)
        {
            var insuranceType = await _service.GetById(insuranceTypeId);
            return Ok(insuranceType);  
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var insuranceType = await _service.GetAll(); 
            return this.Ok(insuranceType);    
        }

        [HttpPost]
        public async Task<IActionResult> Create(InsuranceType insuranceType)
        {
            await _service.Create(insuranceType);
            return CreatedAtAction(nameof(GetById), new { id = insuranceType.InsuranceTypeID }, insuranceType);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string insuranceTypeId)
        {
            await _service.Delete(insuranceTypeId);
            return Ok($"insurance type with id {insuranceTypeId} was deleted.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(InsuranceType insuranceType)
        {
            await _service.Update(insuranceType);
            return Ok($"insurance type with id {insuranceType.InsuranceTypeID} was updated.");
        }
    }
}