using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Analista.Models;
using Analista.Persintencia;
using Analista.Services;

namespace Analista.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTipoRequisitoesController : ControllerBase
    {
        private readonly SubTipoRequisitoService _servicio;

        public SubTipoRequisitoesController(SubTipoRequisitoService servicio)
        {
            _servicio = servicio;
        }

        // GET: api/SubTipoRequisitoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubTipoRequisito>>> GetSubTiposRequisito()
        {
            return await _servicio
        }

        // GET: api/SubTipoRequisitoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubTipoRequisito>> GetSubTipoRequisito(Guid id)
        {
            var subTipoRequisito = await _context.SubTiposRequisito.FindAsync(id);

            if (subTipoRequisito == null)
            {
                return NotFound();
            }

            return subTipoRequisito;
        }

        // PUT: api/SubTipoRequisitoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubTipoRequisito(Guid id, SubTipoRequisito subTipoRequisito)
        {
            if (id != subTipoRequisito.Id)
            {
                return BadRequest();
            }

            _context.Entry(subTipoRequisito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubTipoRequisitoExists(id))
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

        // POST: api/SubTipoRequisitoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubTipoRequisito>> PostSubTipoRequisito(SubTipoRequisito subTipoRequisito)
        {
            _context.SubTiposRequisito.Add(subTipoRequisito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubTipoRequisito", new { id = subTipoRequisito.Id }, subTipoRequisito);
        }

        // DELETE: api/SubTipoRequisitoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubTipoRequisito(Guid id)
        {
            var subTipoRequisito = await _context.SubTiposRequisito.FindAsync(id);
            if (subTipoRequisito == null)
            {
                return NotFound();
            }

            _context.SubTiposRequisito.Remove(subTipoRequisito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubTipoRequisitoExists(Guid id)
        {
            return _context.SubTiposRequisito.Any(e => e.Id == id);
        }
    }
}
