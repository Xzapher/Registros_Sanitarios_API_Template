using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registros_Sanitarios.Application.CQRS.Commands.Hospitales.CreateHospital;
using RegistrosSanitarios.Domain.Entities;
using RegistrosSanitarios.Domain.Repositories;

namespace RegistrosSanitarios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalesController : ControllerBase
    {
        private readonly IHospitalRepository _hospitalRepository;

        private readonly IMediator _mediator;

        public HospitalesController(IHospitalRepository hospitalRepository, IMediator mediator)
        {
            _hospitalRepository = hospitalRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hospital>>> GetHospitales()
        {
            var hospitales = await _hospitalRepository.GetAllAsync();
            return Ok(hospitales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hospital>> GetHospital(int id)
        {
            var hospital = await _hospitalRepository.GetByIdAsync(id);
            if (hospital == null)
            {
                return NotFound();
            }
            return Ok(hospital);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospital(int id, Hospital hospital)
        {
            if (id != hospital.Id)
            {
                return BadRequest();
            }

            try
            {
                await _hospitalRepository.UpdateAsync(hospital);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _hospitalRepository.ExistsAsync(id))
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
        public async Task<IActionResult> PostHospital([FromBody] CreateHospitalCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospital(int id)
        {
            var hospital = await _hospitalRepository.GetByIdAsync(id);
            if (hospital == null)
            {
                return NotFound();
            }

            await _hospitalRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
