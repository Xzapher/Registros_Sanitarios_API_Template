using System.Collections.Generic;
using System.Threading.Tasks;
using Registros_Sanitarios_API.Models;
using Registros_Sanitarios_API.Models.Entities;
using Registros_Sanitarios_API.Repositories;

namespace Registros_Sanitarios_API.Services
{
    public class HospitaleService : IHospitaleService
    {
        private readonly IHospitaleRepository _hospitaleRepository;

        public HospitaleService(IHospitaleRepository hospitaleRepository)
        {
            _hospitaleRepository = hospitaleRepository;
        }

        public async Task<IEnumerable<Hospitale>> GetAllAsync()
        {
            return await _hospitaleRepository.GetAllAsync();
        }

        public async Task<Hospitale> GetByIdAsync(int id)
        {
            return await _hospitaleRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Hospitale hospitale)
        {
            await _hospitaleRepository.AddAsync(hospitale);
        }

        public async Task UpdateAsync(Hospitale hospitale)
        {
            await _hospitaleRepository.UpdateAsync(hospitale);
        }

        public async Task DeleteAsync(int id)
        {
            await _hospitaleRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(int id) // Add this method
        {
            return await _hospitaleRepository.ExistsAsync(id);
        }
    }
}
