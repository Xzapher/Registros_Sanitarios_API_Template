using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistrosSanitarios.Domain.Entities;
using RegistrosSanitarios.Domain.Services;

namespace RegistrosSanitarios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalesController : ControllerBase
    {
        private readonly IHospitaleService _hospitaleService;

        public HospitalesController(IHospitaleService hospitaleService)
        {
            _hospitaleService = hospitaleService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hospitale>>> GetHospitales()
        {
            var hospitales = await _hospitaleService.GetAllAsync();
            return Ok(hospitales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Hospitale>> GetHospitale(int id)
        {
            var hospitale = await _hospitaleService.GetByIdAsync(id);
            if (hospitale == null)
            {
                return NotFound();
            }
            return Ok(hospitale);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHospitale(int id, Hospitale hospitale)
        {
            if (id != hospitale.Id)
            {
                return BadRequest();
            }

            try
            {
                await _hospitaleService.UpdateAsync(hospitale);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _hospitaleService.ExistsAsync(id))
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
        public async Task<ActionResult<Hospitale>> PostHospitale(Hospitale hospitale)
        {
            await _hospitaleService.AddAsync(hospitale);
            return CreatedAtAction("GetHospitale", new { id = hospitale.Id }, hospitale);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHospitale(int id)
        {
            var hospitale = await _hospitaleService.GetByIdAsync(id);
            if (hospitale == null)
            {
                return NotFound();
            }

            await _hospitaleService.DeleteAsync(id);
            return NoContent();
        }
    }
}
