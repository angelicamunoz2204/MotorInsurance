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
        public async Task<Client> Create(Client client)
        {
            await _clientCollection.InsertOneAsync(client);
            return client;
        }

        public async Task<Client> Delete(string clientId)
        {
            await _clientCollection.DeleteOneAsync(x => x.ClientID == clientId);
            return null;
        }

        public async Task<List<Client>> GetAll()
        {
            return await _clientCollection.Find(x => true).ToListAsync();
        }

        public async Task<Client> GetById(string clientId)
        {
            return await _clientCollection.Find(x => x.ClientID == clientId).FirstOrDefaultAsync();
        }

        public async Task<Client> Update(Client client)
        {
            await _clientCollection.ReplaceOneAsync(x => x.ClientID == client.ClientID, client);
            return client;
        }
    }
}