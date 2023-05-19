using MongoDB.Driver;
using MotorInsurance.Models;

namespace MotorInsurance.Repository.Clients
{
    public class ClientsRepository : IClientsRepository
    {
        private readonly IMongoCollection<Client> _clientCollection;

        public ClientsRepository(IMongoDatabase mongoDatabase)
        {
            _clientCollection = mongoDatabase.GetCollection<Client>("clients");
        }
        public Task Create(Client client)
        {
            return _clientCollection.InsertOneAsync(client);
        }

        public Task Delete(string clientId)
        {
            return _clientCollection.DeleteOneAsync(x => x.ClientID == clientId);
        }

        public async Task<List<Client>> GetAll()
        {
            return await _clientCollection.Find(x => true).ToListAsync();
        }

        public async Task<Client> GetById(string clientId)
        {
            return await _clientCollection.Find(x => x.ClientID == clientId).FirstOrDefaultAsync();
        }

        public Task Update(Client client)
        {
            return _clientCollection.ReplaceOneAsync(x => x.ClientID == client.ClientID, client);
        }
    }
}