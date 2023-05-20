using MotorInsurance.Models;
using MongoDB.Driver;

namespace MotorInsurance.Repository.InsuranceTypes
{
    public class InsuranceTypesRepository : IInsuranceTypesRepository
    {

        private readonly IMongoCollection<InsuranceType> _insuranceTypeCollection;

        public InsuranceTypesRepository(IMongoDatabase mongoDatabase)
        {
            _insuranceTypeCollection = mongoDatabase.GetCollection<InsuranceType>("insuranceTypes");
        }

        public async Task<InsuranceType> Create(InsuranceType insuranceType)
        {
            await _insuranceTypeCollection.InsertOneAsync(insuranceType);
            return insuranceType;
        }

        public async Task<InsuranceType> Delete(string insuranceTypeId)
        {
            await _insuranceTypeCollection.DeleteOneAsync(x => x.InsuranceTypeID == insuranceTypeId);
            return null;
        }

        public async Task<InsuranceType> GetById(string insuranceTypeId)
        {
            return await _insuranceTypeCollection.Find(x => x.InsuranceTypeID == insuranceTypeId).FirstOrDefaultAsync();
        }

        public async Task<List<InsuranceType>> GetAll()
        {
            return await _insuranceTypeCollection.Find(x => true).ToListAsync();
        }

        public async Task<InsuranceType> Update(InsuranceType insuranceType)
        {
            await _insuranceTypeCollection.ReplaceOneAsync(x => x.InsuranceTypeID == insuranceType.InsuranceTypeID, insuranceType);
            return insuranceType;
        }
    }
}