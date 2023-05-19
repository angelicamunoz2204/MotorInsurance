using Microsoft.AspNetCore.Mvc;
using MotorInsurance.Models;
using MotorInsurance.Services.Clients;

namespace motorInsurance.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientsService _service;

        public ClientController(IClientsService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string clientId)
        {
            var client = await _service.GetById(clientId);
            if(client == null)
            {
                return NotFound();
            }

            return Ok(client);  
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _service.GetAll(); 
            return this.Ok(clients);    
        }

        [HttpPost]
        public async Task<IActionResult> Create(Client client)
        {
            await _service.Create(client);
            return CreatedAtAction(nameof(GetById), new { id = client.ClientID}, client);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string clientId)
        {
            var client = await _service.GetById(clientId);
            if(client == null)
            {
                return NotFound();
            }

            await _service.Delete(clientId);
            return Ok($"client type with id {clientId} was deleted.");
        }

        [HttpPut]
        public async Task<IActionResult> Update(Client client)
        {
            var clientU = await _service.GetById(client.ClientID);

            if(clientU == null)
            {
                return NotFound();
            }

            await _service.Update(client);
            return Ok($"client with id {client.ClientID} was updated.");
        }
    }
}