using MotorInsurance.Models;

namespace MotorInsurance.Services.Vehicles
{
    public interface IVehiclesService
    {
        Task<Vehicle> GetByPlate(string licensePlate);
        Task<List<Vehicle>> GetAll();
        Task<Vehicle> Create(Vehicle vehicle);
        Task<Vehicle> Update(Vehicle vehicle);
        Task<Vehicle> Delete(string licensePlate);
    }
}