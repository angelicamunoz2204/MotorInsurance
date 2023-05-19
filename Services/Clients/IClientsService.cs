using MotorInsurance.Models;

namespace MotorInsurance.Services.Clients
{
    public interface IClientsService
    {
        Task<Client> GetById(string clientId);
        Task<List<Client>> GetAll();
        Task Create(Client client);
        Task Update(Client client);
        Task Delete(string clientId);
    }
}