using MotorInsurance.Models;

namespace MotorInsurance.Services.Insurances
{
    public interface IInsurancesService
    {
        Task<Insurance> GetById(string insuranceId);
        Task<List<Insurance>> GetAll();
        Task Create(Insurance insurance);
        Task Update(Insurance insurance);
        Task Delete(string insuranceId);        
    }
}