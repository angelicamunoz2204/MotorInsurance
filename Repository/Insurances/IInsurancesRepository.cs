using MotorInsurance.Models;

namespace MotorInsurance.Repository.Insurances
{
    public interface IInsurancesRepository
    {
        Task<Insurance> GetById(string insuranceId);
        Task<List<Insurance>> GetAll();
        Task Create(Insurance insurance);
        Task Update(Insurance insurance);
        Task Delete(string insuranceId);
    }
}