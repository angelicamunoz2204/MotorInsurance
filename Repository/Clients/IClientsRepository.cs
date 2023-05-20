using MotorInsurance.Models;

namespace MotorInsurance.Repository.Clients
{
    public interface IClientsRepository
    {
        Task<Client> GetById(string clientId);
        Task<List<Client>> GetAll();
        Task<Client> Create(Client client);
        Task<Client> Update(Client client);
        Task<Client> Delete(string clientId);
    }
}