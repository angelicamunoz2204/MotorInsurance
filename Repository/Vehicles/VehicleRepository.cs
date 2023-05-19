using MongoDB.Driver;
using MotorInsurance.Models;

namespace MotorInsurance.Repository.Vehicles
{
    public class VehiclesRepository : IVehiclesRepository
    {
        private readonly IMongoCollection<Vehicle> _vehicleCollection;

        public VehiclesRepository(IMongoDatabase mongoDatabase)
        {
            _vehicleCollection = mongoDatabase.GetCollection<Vehicle>("vehicles");
        }
        public Task Create(Vehicle vehicle)
        {
            return _vehicleCollection.InsertOneAsync(vehicle);
        }

        public Task Delete(string licensePlate)
        {
            return _vehicleCollection.DeleteOneAsync(x => x.LicensePlate == licensePlate);
        }

        public async Task<List<Vehicle>> GetAll()
        {
            return await _vehicleCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Vehicle> GetByPlate(string licensePlate)
        {
            return await _vehicleCollection.Find(_ => _.LicensePlate == licensePlate).FirstOrDefaultAsync();
        }

        public Task Update(Vehicle vehicle)
        {
            return _vehicleCollection.ReplaceOneAsync(x => x.LicensePlate == vehicle.LicensePlate, vehicle);
        }
    }
}