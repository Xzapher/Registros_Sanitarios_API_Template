using RegistrosSanitarios.Domain.Entities;

namespace RegistrosSanitarios.Domain.Repositories
{
    public interface IHospitaleRepository
    {
        Task<IEnumerable<Hospitale>> GetAllAsync();
        Task<Hospitale> GetByIdAsync(int id);
        Task AddAsync(Hospitale hospitale);
        Task UpdateAsync(Hospitale hospitale);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
