using MotorInsurance.Models;

namespace MotorInsurance.Services.InsuranceTypes
{
    public interface IInsuranceTypesService
    {
        Task<InsuranceType> GetById(string insuranceTypeId);
        Task<List<InsuranceType>> GetAll();
        Task Create(InsuranceType insuranceType);
        Task Update(InsuranceType insuranceType);
        Task Delete(string insuranceTypeId);
    }
}