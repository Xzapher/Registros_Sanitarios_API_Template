using MediatR;
using Microsoft.AspNetCore.Mvc;
using RegistrosSanitarios.Application.CQRS.Commands.Hospitales;
using RegistrosSanitarios.Application.CQRS.Queries.Hospitales;
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
            var hospitales = await _mediator.Send(new GetAllHospitalesQuery());
            return Ok(hospitales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hospital>> GetHospitalById(int id)
        {
            var hospital = await _mediator.Send(new GetHospitalByIdQuery(id));
            if (hospital == null) return NotFound();
            return Ok(hospital);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditHospital(int id, [FromBody] UpdateHospitalCommand command)
        {
            if (id != command.Id) return BadRequest("ID mismatch");

            var success = await _mediator.Send(command);
            if (!success) return NotFound();
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateHospital([FromBody] CreateHospitalCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospital(int id, CancellationToken ct)
        {
            if (id <= 0)
                return BadRequest("ID inválido");

            var success = await _mediator.Send(new DeleteHospitalCommand(id), ct);

            if (!success)
                return NotFound("Hospital no encontrado o no se puede eliminar");

            return NoContent();
        }
    }
}
