using RegistrosSanitarios.Domain.Entities;

namespace RegistrosSanitarios.Domain.Repositories
{
    public interface IHospitalRepository
    {
        Task<IEnumerable<Hospital>> GetAllAsync();
        Task<Hospital> GetByIdAsync(int id);
        Task AddAsync(Hospital hospital);
        Task UpdateAsync(Hospital hospital);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
