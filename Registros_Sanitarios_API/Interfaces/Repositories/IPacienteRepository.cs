using System.Collections.Generic;
using System.Threading.Tasks;
using Registros_Sanitarios_API.Models.Entities;

namespace Registros_Sanitarios_API.Repositories
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> GetAllAsync();
        Task<Paciente> GetByIdAsync(int id);
        Task AddAsync(Paciente paciente);
        Task UpdateAsync(Paciente paciente);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id); // Ensure this line is present
    }
}
