using System.Collections.Generic;
using System.Threading.Tasks;
using Registros_Sanitarios_API.Models.Entities;
using Registros_Sanitarios_API.Repositories;

namespace Registros_Sanitarios_API.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<IEnumerable<Paciente>> GetAllAsync()
        {
            return await _pacienteRepository.GetAllAsync();
        }

        public async Task<Paciente> GetByIdAsync(int id)
        {
            return await _pacienteRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Paciente paciente)
        {
            await _pacienteRepository.AddAsync(paciente);
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            await _pacienteRepository.UpdateAsync(paciente);
        }

        public async Task DeleteAsync(int id)
        {
            await _pacienteRepository.DeleteAsync(id);
        }

        public async Task<bool> ExistsAsync(int id) // Add this method
        {
            return await _pacienteRepository.ExistsAsync(id);
        }
    }
}
