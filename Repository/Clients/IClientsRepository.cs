using MotorInsurance.Models;

namespace MotorInsurance.Repository.Clients
{
    public interface IClientsRepository
    {
        Task<Client> GetById(string clientId);
        Task<List<Client>> GetAll();
        Task Create(Client client);
        Task Update(Client client);
        Task Delete(string clientId);
    }
}