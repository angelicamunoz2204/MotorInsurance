using MotorInsurance.Models;
using MotorInsurance.Repository.InsuranceTypes;
using MotorInsurance.Services.Exceptions;

namespace MotorInsurance.Services.InsuranceTypes
{
    public class InsuranceTypesService : IInsuranceTypesService
    {
        private readonly IInsuranceTypesRepository _repository;

        public InsuranceTypesService(IInsuranceTypesRepository repository)
        {
            _repository = repository;
        }
        public Task<InsuranceType> Create(InsuranceType insuranceType)
        {
            return this._repository.Create(insuranceType);
        }

        public async Task<InsuranceType> Delete(string insuranceTypeId)
        {
            var insuranceType = await this._repository.GetById(insuranceTypeId);

            if(insuranceType == null)
            {
                throw new NotExistentException("insurance type", insuranceTypeId);
            }

            return null;
        }

        public Task<List<InsuranceType>> GetAll()
        {
            return this._repository.GetAll();
        }

        public async Task<InsuranceType> GetById(string insuranceTypeId)
        {
            var insuranceType = await this._repository.GetById(insuranceTypeId);

            if(insuranceType == null)
            {
                throw new NotExistentException("insurance type", insuranceTypeId);
            }

            return insuranceType;
        }

        public async Task<InsuranceType> Update(InsuranceType insuranceType)
        {
            var insuranceTypeId = insuranceType.InsuranceTypeID;
            var insuranceTypeU = await this._repository.GetById(insuranceTypeId);

            if(insuranceTypeU == null)
            {
                throw new NotExistentException("insurance type", insuranceTypeId);
            }

            return insuranceTypeU;
        }
    }
}