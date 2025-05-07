using log4net;
using Microsoft.EntityFrameworkCore;
using RegistrosSanitarios.Domain.Entities;
using RegistrosSanitarios.Domain.Repositories;
using RegistrosSanitarios.Infrastructure.Data;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace RegistrosSanitarios.Infrastructure.Repositories;

public class HospitalRepository : IHospitalRepository
{
    private readonly RegistrosSanitariosContext _context;

    private static readonly ILog log = LogManager.GetLogger(typeof(HospitalRepository));

    public HospitalRepository(RegistrosSanitariosContext context)
    {
        _context = context;
    }

    /// Example method to demonstrate transaction handling
    public async Task<IEnumerable<Hospital>> GetAllExample(Hospital hospital)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            log.Info("Se ha intentado usar una llamada no implementada");
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            // Tengo que cambiar la forma en la que se llama al nombre del mismo método
            log.Error($"Hubo un error en el método {System.Reflection.MethodBase.GetCurrentMethod()?.Name}: {ex.Message}", ex);
            await transaction.RollbackAsync();
            throw;
        }

        await transaction.CommitAsync();
        return await _context.Hospitales.ToListAsync();

    }

    public async Task<IEnumerable<Hospital>> GetHospitalesAsync()
    {
        return await _context.Hospitales.ToListAsync();
    }


    public async Task<Hospital> GetHospitalByIdAsync(int id)
    {
        return await _context.Hospitales.FindAsync(id);
    }

    public async Task AddHospitalAsync(Hospital hospital)
    {
        await _context.Hospitales.AddAsync(hospital);
        await _context.SaveChangesAsync();
    }

    public async Task EditHospitalAsync(Hospital hospital)
    {
        _context.Entry(hospital).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteHospitalAsync(int id, CancellationToken ct)
    {
        var hospital = new Hospital { Id = id };
        _context.Hospitales.Attach(hospital);
        _context.Hospitales.Remove(hospital);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Hospitales.AnyAsync(e => e.Id == id);
    }

    public async Task<Hospital?> GetByIdWithPacientesAsync(int id, CancellationToken ct)
    {
        return await _context.Hospitales
        .Include(h => h.Pacientes)
        .FirstOrDefaultAsync(h => h.Id == id, ct);
    }
}