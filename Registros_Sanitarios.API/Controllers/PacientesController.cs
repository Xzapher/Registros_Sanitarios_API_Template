using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrosSanitarios.Domain.Entities;
using RegistrosSanitarios.Domain.Repositories;

namespace RegistrosSanitarios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacientesController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
        {
            var pacientes = await _pacienteRepository.GetAllAsync();
            return Ok(pacientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPaciente(int id)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return Ok(paciente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(int id, Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return BadRequest();
            }

            try
            {
                await _pacienteRepository.UpdateAsync(paciente);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _pacienteRepository.ExistsAsync(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Paciente>> PostPaciente(Paciente paciente)
        {
            await _pacienteRepository.AddAsync(paciente);
            return CreatedAtAction("GetPaciente", new { id = paciente.Id }, paciente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaciente(int id)
        {
            var paciente = await _pacienteRepository.GetByIdAsync(id);
            if (paciente == null)
            {
                return NotFound();
            }

            await _pacienteRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
