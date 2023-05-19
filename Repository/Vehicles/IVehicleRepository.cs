using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MotorInsurance.Models;

namespace MotorInsurance.Repository.Vehicles
{
    public interface IVehiclesRepository
    {
        Task<Vehicle> GetByPlate(string licensePlate);
        Task<List<Vehicle>> GetAll();
        Task Create(Vehicle vehicle);
        Task Update(Vehicle vehicle);
        Task Delete(string licensePlate);
    }
}