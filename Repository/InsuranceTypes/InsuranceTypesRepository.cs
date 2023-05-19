using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public Task Create(InsuranceType insuranceType)
        {
            return _insuranceTypeCollection.InsertOneAsync(insuranceType);
        }

        public Task Delete(string insuranceTypeId)
        {
            return _insuranceTypeCollection.DeleteOneAsync(x => x.InsuranceTypeID == insuranceTypeId);
        }

        public async Task<InsuranceType> GetById(string insuranceTypeId)
        {
            return await _insuranceTypeCollection.Find(x => x.InsuranceTypeID == insuranceTypeId).FirstOrDefaultAsync();
        }

        public async Task<List<InsuranceType>> GetAll()
        {
            return await _insuranceTypeCollection.Find(x => true).ToListAsync();
        }

        public Task Update(InsuranceType insuranceType)
        {
            return _insuranceTypeCollection.ReplaceOneAsync(x => x.InsuranceTypeID == insuranceType.InsuranceTypeID, insuranceType);
        }
    }
}