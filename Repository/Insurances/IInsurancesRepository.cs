using MotorInsurance.Models;

namespace MotorInsurance.Repository.Insurances
{
    public interface IInsurancesRepository
    {
        Task<Insurance> GetById(string insuranceId);
        Task<Insurance> GetByVehicleLicensePlate(string vehicleLicensePLate);
        Task<List<Insurance>> GetAll();
        Task<Insurance> Create(Insurance insurance);
        Task<Insurance> Update(Insurance insurance);
        Task<Insurance> Delete(string insuranceId);
    }
}