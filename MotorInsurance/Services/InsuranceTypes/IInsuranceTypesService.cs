using MotorInsurance.Models;

namespace MotorInsurance.Services.InsuranceTypes
{
    public interface IInsuranceTypesService
    {
        Task<InsuranceType> GetById(string insuranceTypeId);
        Task<List<InsuranceType>> GetAll();
        Task<InsuranceType> Create(InsuranceType insuranceType);
        Task<InsuranceType> Update(InsuranceType insuranceType);
        Task<InsuranceType> Delete(string insuranceTypeId);
    }
}