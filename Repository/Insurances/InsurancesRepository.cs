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
        public async Task<Insurance> Create(Insurance insurance)
        {
            await _insuranceCollection.InsertOneAsync(insurance);
            return insurance;
        }

        public async Task<Insurance> Delete(string insuranceId)
        {
            await _insuranceCollection.DeleteOneAsync(x => x.InsuranceID == insuranceId);
            return null;
        }

        public async Task<List<Insurance>> GetAll()
        {
            return await _insuranceCollection.Find(x => true).ToListAsync();
        }

        public async Task<Insurance> GetById(string insuranceId)
        {
            return await _insuranceCollection.Find(x => x.InsuranceID == insuranceId).FirstOrDefaultAsync();
        }

        public async Task<Insurance> GetByVehicleLicensePlate(string vehicleLicensePLate)
        {
            return await _insuranceCollection.Find(x => x.Vehicle.LicensePlate == vehicleLicensePLate).FirstOrDefaultAsync();
        }

        public async Task<Insurance> Update(Insurance insurance)
        {
            await _insuranceCollection.ReplaceOneAsync(x => x.InsuranceID == insurance.InsuranceID, insurance);
            return insurance;
        }
    }
}