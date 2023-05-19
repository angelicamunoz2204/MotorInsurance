using MongoDB.Driver;
using MotorInsurance.Models;

namespace MotorInsurance.Repository.Insurances
{
    public class InsurancesRepository : IInsurancesRepository
    {
        private readonly IMongoCollection<Insurance> _insuranceCollection;

        public InsurancesRepository(IMongoDatabase mongoDatabase)
        {
            _insuranceCollection = mongoDatabase.GetCollection<Insurance>("insurances");
        }
        public Task Create(Insurance insurance)
        {
            return _insuranceCollection.InsertOneAsync(insurance);
        }

        public Task Delete(string insuranceId)
        {
            return _insuranceCollection.DeleteOneAsync(x => x.InsuranceID == insuranceId);
        }

        public async Task<List<Insurance>> GetAll()
        {
            return await _insuranceCollection.Find(x => true).ToListAsync();
        }

        public async Task<Insurance> GetById(string insuranceId)
        {
            return await _insuranceCollection.Find(x => x.InsuranceID == insuranceId).FirstOrDefaultAsync();
        }

        public Task Update(Insurance insurance)
        {
            return _insuranceCollection.ReplaceOneAsync(x => x.InsuranceID == insurance.InsuranceID, insurance);
        }
    }
}