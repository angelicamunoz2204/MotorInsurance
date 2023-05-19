using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MotorInsurance.Models;

namespace MotorInsurance.Repository.InsuranceTypes
{
    public interface IInsuranceTypesRepository
    {
        Task<InsuranceType> GetById(string insuranceTypeId);
        Task<List<InsuranceType>> GetAll();
        Task Create(InsuranceType insuranceType);
        Task Update(InsuranceType insuranceType);
        Task Delete(string insuranceTypeId);
    }
}