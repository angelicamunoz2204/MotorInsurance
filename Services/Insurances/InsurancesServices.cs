using MotorInsurance.Models;
using MotorInsurance.Repository.Insurances;

namespace MotorInsurance.Services.Insurances
{
    public class InsurancesService : IInsurancesService
    {
        private readonly IInsurancesRepository _repository;

        public InsurancesService(IInsurancesRepository repository)
        {
            _repository = repository;
        }  
        public Task Create(Insurance insurance)
        {
            return this._repository.Create(insurance);
        }

        public Task Delete(string insuranceId)
        {
            return this._repository.Delete(insuranceId);
        }

        public Task<List<Insurance>> GetAll()
        {
            return this._repository.GetAll();
        }

        public Task<Insurance> GetById(string insuranceId)
        {
            return this._repository.GetById(insuranceId);
        }

        public Task Update(Insurance insurance)
        {
            return this._repository.Update(insurance);
        }
    }
}