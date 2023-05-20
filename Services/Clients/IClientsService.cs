using MotorInsurance.Models;

namespace MotorInsurance.Services.Clients
{
    public interface IClientsService
    {
        Task<Client> GetById(string clientId);
        Task<List<Client>> GetAll();
        Task<Client> Create(Client client);
        Task<Client> Update(Client client);
        Task<Client> Delete(string clientId);
    }
}