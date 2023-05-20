
using MotorInsurance.Models;
using MotorInsurance.Repository.Clients;
using MotorInsurance.Repository.Insurances;
using MotorInsurance.Repository.InsuranceTypes;
using MotorInsurance.Repository.Vehicles;
using MotorInsurance.Services.Exceptions;

namespace MotorInsurance.Services.Insurances
{
    public class InsurancesService : IInsurancesService
    {
        private readonly IInsurancesRepository _repository;
        private readonly IInsuranceTypesRepository _insuranceTypesRepository;
        private readonly IVehiclesRepository _vehiclesRepository;
        private readonly IClientsRepository _clientsRepository;

        public InsurancesService(IInsurancesRepository repository, 
               IInsuranceTypesRepository insuranceTypesRepository,
               IVehiclesRepository vehiclesRepository,
               IClientsRepository clientsRepository)
        {
            _repository = repository;
            _insuranceTypesRepository = insuranceTypesRepository;
            _vehiclesRepository = vehiclesRepository;
            _clientsRepository = clientsRepository;
        }  
        public async Task<Insurance> Create(Insurance insurance)
        {
            if(!verifyInsureEffect(insurance.StartDate, insurance.EndDate))
            {
                throw new InvalidDateException();
            }

            insurance = await createIfNotExists(insurance);

            return await this._repository.Create(insurance);
        }

        public Task<Insurance> Delete(string insuranceId)
        {
            var insurance = this._repository.GetById(insuranceId);

            if (insurance == null)
            {
                throw new NotExistentException("insurance", insuranceId);
            }

            return this._repository.Delete(insuranceId);
        }

        public Task<List<Insurance>> GetAll()
        {
            return this._repository.GetAll();
        }

        public Task<Insurance> GetById(string insuranceId)
        {
            var insurance= this._repository.GetById(insuranceId);

            if (insurance == null)
            {
                throw new NotExistentException("insurance", insuranceId);
            }
            
            return insurance;
        }

        public Task<Insurance> GetByVehicleLicensePlate(string vehicleLicensePLate)
        {
            var insurance= this._repository.GetByVehicleLicensePlate(vehicleLicensePLate);

            if (insurance == null)
            {
                throw new NotExistentException("insurance", vehicleLicensePLate);
            }

            return insurance;
        }

        public async Task<Insurance> Update(Insurance insurance)
        {
            if(!verifyInsureEffect(insurance.StartDate, insurance.EndDate))
            {
                throw new InvalidDateException();
            }

            var insuranceId = insurance.InsuranceID;
            var insuranceU= this._repository.GetById(insuranceId);
            if (insuranceU == null)
            {
                throw new NotExistentException("insurance", insuranceId);
            }

            insurance = await createIfNotExists(insurance);
            
            return await this._repository.Update(insurance);
        }

        public async Task<Insurance> createIfNotExists(Insurance insurance)
        {
            var newInsuranceType = insurance.InsuranceType;
            var oldInsuranceType = await this._insuranceTypesRepository.GetById(newInsuranceType.InsuranceTypeID);
            if (oldInsuranceType == null)
            {
                newInsuranceType = await this._insuranceTypesRepository.Create(newInsuranceType);
            }

            var newVehicle = insurance.Vehicle;
            var oldVehicle = await this._vehiclesRepository.GetByPlate(newVehicle.LicensePlate);
            if (oldVehicle == null)
            {
                newVehicle = await this._vehiclesRepository.Create(newVehicle);
            }

            var newClient = insurance.Client;
            var oldClient = await this._clientsRepository.GetById(newClient.ClientID);
            if (oldClient == null)
            {
                newClient = await this._clientsRepository.Create(newClient);
            }

            return insurance;
        }

        public bool verifyInsureEffect(DateTime start, DateTime end)
        {
            DateTime today = DateTime.Now;
            DateTime startDate = start;
            DateTime endDate = end;
            int checkValidEndDate = DateTime.Compare(today, endDate);
            int checkValidStartDate = DateTime.Compare(startDate, endDate);

            if(checkValidEndDate >= 0 || checkValidStartDate >= 0)
            {
                return false;
            }

            return true;
        }
    }
}