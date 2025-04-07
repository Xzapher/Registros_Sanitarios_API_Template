using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Registros_Sanitarios_API.Data;
using Registros_Sanitarios_API.Models.Entities;

namespace Registros_Sanitarios_API.Repositories
{
    public class HospitaleRepository : IHospitaleRepository
    {
        private readonly RegistrosSanitariosContext _context;

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