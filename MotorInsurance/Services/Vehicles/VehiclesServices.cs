using MotorInsurance.Models;
using MotorInsurance.Repository.Vehicles;
using MotorInsurance.Services.Exceptions;

namespace MotorInsurance.Services.Vehicles
{
    public class VehiclesService : IVehiclesService
    {
        private readonly IVehiclesRepository _repository;

        public VehiclesService(IVehiclesRepository repository)
        {
            _repository = repository;
        }   
        public async Task<Vehicle> Create(Vehicle vehicle)
        {
            return await this._repository.Create(vehicle);
        }

        public async Task<Vehicle> Delete(string licensePlate)
        {
            var vehicle = await this._repository.GetByPlate(licensePlate);

            if(vehicle == null)
            {
                throw new NotExistentException("vehicle", licensePlate);
            }

            await this._repository.Delete(licensePlate);
            return null;
        }

        public Task<List<Vehicle>> GetAll()
        {
            return this._repository.GetAll();
        }      

        public async Task<Vehicle> GetByPlate(string licensePlate)
        {
            var vehicle = await this._repository.GetByPlate(licensePlate);

            if(vehicle == null)
            {
                throw new NotExistentException("vehicle", licensePlate);
            }

            return vehicle;
        }

        public async Task<Vehicle> Update(Vehicle vehicle)
        {
            var vehicleLicensePlate = vehicle.LicensePlate;
            var vehicleU = await this._repository.GetByPlate(vehicleLicensePlate);

            if(vehicleU == null)
            {
                throw new NotExistentException("vehicle", vehicleLicensePlate);
            }

            return await this._repository.Update(vehicle);
        }
    }
}