using System.Collections.Generic;
using System.Threading.Tasks;
using Registros_Sanitarios_API.Models;
using Registros_Sanitarios_API.Models.Entities;

namespace Registros_Sanitarios_API.Services
{
    public interface IHospitaleService
    {
        Task<IEnumerable<Hospitale>> GetAllAsync();
        Task<Hospitale> GetByIdAsync(int id);
        Task AddAsync(Hospitale hospitale);
        Task UpdateAsync(Hospitale hospitale);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id); // Add this line
    }
}
