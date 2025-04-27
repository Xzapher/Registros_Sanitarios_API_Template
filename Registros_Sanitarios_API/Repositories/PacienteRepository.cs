using Microsoft.EntityFrameworkCore;
using Registros_Sanitarios_API.Data;
using Registros_Sanitarios_API.Models.Entities;

namespace Registros_Sanitarios_API.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly RegistrosSanitariosContext _context;

        public PacienteRepository(RegistrosSanitariosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paciente>> GetAllAsync()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Paciente> GetByIdAsync(int id)
        {
            return await _context.Pacientes.FindAsync(id);
        }

        public async Task AddAsync(Paciente paciente)
        {
            await _context.Pacientes.AddAsync(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            _context.Entry(paciente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Pacientes.AnyAsync(e => e.Id == id);
        }
    }
}
