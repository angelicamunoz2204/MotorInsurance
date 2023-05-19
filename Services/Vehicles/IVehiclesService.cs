using MotorInsurance.Models;

namespace MotorInsurance.Services.Vehicles
{
    public interface IVehiclesService
    {
        Task<Vehicle> GetByPlate(string licensePlate);
        Task<List<Vehicle>> GetAll();
        Task Create(Vehicle vehicle);
        Task Update(Vehicle vehicle);
        Task Delete(string licensePlate);
    }
}