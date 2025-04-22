using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using log4net;
using Microsoft.EntityFrameworkCore;
using Registros_Sanitarios_API.Data;
using Registros_Sanitarios_API.Models.Entities;

namespace Registros_Sanitarios_API.Repositories
{
    public class HospitaleRepository : IHospitaleRepository
    {
        private readonly RegistrosSanitariosContext _context;

        private static readonly ILog log = LogManager.GetLogger(typeof(HospitaleRepository));

        /// Example method to demonstrate transaction handling
        public async Task<IEnumerable<Hospitale>> GetAllExample(Hospitale hospitale)
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


        public HospitaleRepository(RegistrosSanitariosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Hospitale>> GetAllAsync()
        {
            return await _context.Hospitales.ToListAsync();
        }

        public async Task<Hospitale> GetByIdAsync(int id)
        {
            return await _context.Hospitales.FindAsync(id);
        }

        public async Task AddAsync(Hospitale hospitale)
        {
            await _context.Hospitales.AddAsync(hospitale);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Hospitale hospitale)
        {
            _context.Entry(hospitale).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var hospitale = await _context.Hospitales.FindAsync(id);
            if (hospitale != null)
            {
                _context.Hospitales.Remove(hospitale);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Hospitales.AnyAsync(e => e.Id == id);
        }
    }
}