using MotorInsurance.Models;
using MotorInsurance.Repository.Clients;
using MotorInsurance.Services.Exceptions;

namespace MotorInsurance.Services.Clients
{
    public class ClientsService : IClientsService
    {
        private readonly IClientsRepository _repository;

        public ClientsService(IClientsRepository repository)
        {
            _repository = repository;
        }        
        public async Task<Client> Create(Client client)
        {
            return await this._repository.Create(client);
        }

        public async Task<Client> Delete(string clientId)
        {
            var client = await _repository.GetById(clientId);
            if(client == null)
            {
                throw new NotExistentException("client", clientId);
            }

            return await this._repository.Delete(clientId);
        }

        public Task<List<Client>> GetAll()
        {
            return this._repository.GetAll();
        }

        public async Task<Client> GetById(string clientId)
        {   
            var client = await _repository.GetById(clientId);
            if(client == null)
            {
                throw new NotExistentException("client", clientId);
            }

            return await this._repository.GetById(clientId);
        }

        public async Task<Client> Update(Client client)
        {
            var clientId = client.ClientID;
            var clientU = await _repository.GetById(clientId);
            if(clientU == null)
            {
                throw new NotExistentException("client", clientId);
            }

            return await this._repository.Update(client);
        }
    }
}