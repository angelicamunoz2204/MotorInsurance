using MotorInsurance.Models;
using MotorInsurance.Repository.Vehicles;

namespace MotorInsurance.Services.Vehicles
{
    public class VehiclesService : IVehiclesService
    {
        private readonly IVehiclesRepository _repository;

        public VehiclesService(IVehiclesRepository repository)
        {
            _repository = repository;
        }   
        public Task Create(Vehicle vehicle)
        {
            return this._repository.Create(vehicle);
        }

        public Task Delete(string licensePlate)
        {
            return this._repository.Delete(licensePlate);
        }

        public Task<List<Vehicle>> GetAll()
        {
            return this._repository.GetAll();
        }

        public Task<Vehicle> GetByPlate(string licensePlate)
        {
            return this._repository.GetByPlate(licensePlate);
        }

        public Task Update(Vehicle vehicle)
        {
            return this._repository.Update(vehicle);
        }
    }
}