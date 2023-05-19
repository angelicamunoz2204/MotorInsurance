using MotorInsurance.Models;
using MotorInsurance.Repository.InsuranceTypes;

namespace MotorInsurance.Services.InsuranceTypes
{
    public class InsuranceTypesService : IInsuranceTypesService
    {
        private readonly IInsuranceTypesRepository _repository;

        public InsuranceTypesService(IInsuranceTypesRepository repository)
        {
            _repository = repository;
        }
        public Task Create(InsuranceType insuranceType)
        {
            return this._repository.Create(insuranceType);
        }

        public Task Delete(string insuranceTypeId)
        {
            return this._repository.Delete(insuranceTypeId);
        }

        public Task<List<InsuranceType>> GetAll()
        {
            return this._repository.GetAll();
        }

        public Task<InsuranceType> GetById(string insuranceTypeId)
        {
            return this._repository.GetById(insuranceTypeId);
        }

        public Task Update(InsuranceType insuranceType)
        {
            return this._repository.Update(insuranceType);
        }
    }
}