using MotorInsurance.Models;

namespace MotorInsurance.Services.Insurances
{
    public interface IInsurancesService
    {
        Task<Insurance> GetById(string insuranceId);
        Task<Insurance> GetByVehicleLicensePlate(string vehicleLicensePLate);
        Task<List<Insurance>> GetAll();
        Task<Insurance> Create(Insurance insurance);
        Task<Insurance> Update(Insurance insurance);
        Task<Insurance> Delete(string insuranceId);        
    }
}