using RegistrosSanitarios.Domain.Entities;

namespace RegistrosSanitarios.Domain.Repositories
{
    public interface IHospitalRepository
    {
        Task<IEnumerable<Hospital>> GetHospitalesAsync();
        Task<Hospital> GetHospitalByIdAsync(int id);
        Task AddHospitalAsync(Hospital hospital);
        Task EditHospitalAsync(Hospital hospital);
        Task DeleteHospitalAsync(int id, CancellationToken ct);
        Task<bool> ExistsAsync(int id);
        Task<Hospital?> GetByIdWithPacientesAsync(int id, CancellationToken ct);
    }
}
