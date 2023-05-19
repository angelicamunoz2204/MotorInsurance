using MotorInsurance.Models;
using MotorInsurance.Repository.Clients;

namespace MotorInsurance.Services.Clients
{
    public class ClientsService : IClientsService
    {
        private readonly IClientsRepository _repository;

        public ClientsService(IClientsRepository repository)
        {
            _repository = repository;
        }        
        public Task Create(Client client)
        {
            return this._repository.Create(client);
        }

        public Task Delete(string clientId)
        {
            return this._repository.Delete(clientId);
        }

        public Task<List<Client>> GetAll()
        {
            return this._repository.GetAll();
        }

        public Task<Client> GetById(string clientId)
        {
            return this._repository.GetById(clientId);
    
        }

        public Task Update(Client client)
        {
            return this._repository.Update(client);
        }
    }
}