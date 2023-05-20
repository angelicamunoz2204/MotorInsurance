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
        public async Task<Vehicle> Create(Vehicle vehicle)
        {
            await _vehicleCollection.InsertOneAsync(vehicle);
            return vehicle;
        }

        public async Task<Vehicle> Delete(string licensePlate)
        {
            await _vehicleCollection.DeleteOneAsync(x => x.LicensePlate == licensePlate);
            return null;
        }

        public async Task<List<Vehicle>> GetAll()
        {
            return await _vehicleCollection.Find(_ => true).ToListAsync();
        }

        public async Task<Vehicle> GetByPlate(string licensePlate)
        {
            return await _vehicleCollection.Find(_ => _.LicensePlate == licensePlate).FirstOrDefaultAsync();
        }

        public async Task<Vehicle> Update(Vehicle vehicle)
        {
            await _vehicleCollection.ReplaceOneAsync(x => x.LicensePlate == vehicle.LicensePlate, vehicle);
            return vehicle;
        }
    }
}