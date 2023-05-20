using MotorInsurance.Models;

namespace MotorInsurance.Repository.InsuranceTypes
{
    public interface IInsuranceTypesRepository
    {
        Task<InsuranceType> GetById(string insuranceTypeId);
        Task<List<InsuranceType>> GetAll();
        Task<InsuranceType> Create(InsuranceType insuranceType);
        Task<InsuranceType> Update(InsuranceType insuranceType);
        Task<InsuranceType> Delete(string insuranceTypeId);
    }
}