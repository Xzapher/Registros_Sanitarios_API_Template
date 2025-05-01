using RegistrosSanitarios.Domain.Entities;

namespace RegistrosSanitarios.Domain.Services
{
    public interface IHospitaleService
    {
        Task<IEnumerable<Hospitale>> GetAllAsync();
        Task<Hospitale> GetByIdAsync(int id);
        Task AddAsync(Hospitale hospitale);
        Task UpdateAsync(Hospitale hospitale);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
