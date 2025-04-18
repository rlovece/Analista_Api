using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Analista.Models;
using Analista.Persintencia;
using Analista.Services.Interfaces;

namespace Analista.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoRequisitoController : ControllerBase
    {
        private readonly ITipoRequisitoService _TipoDeRequisitoService;

        public TipoRequisitoController(ITipoRequisitoService tipoRequisitoService)
        {
            _TipoDeRequisitoService = tipoRequisitoService;
        }


        /// <summary>
        /// Obtiene todos los tipos de requisito disponibles.
        /// </summary>
        /// <remarks>
        /// Este endpoint retorna una lista con todos los tipos de requisito registrados en el sistema.
        /// Es útil para mostrar en formularios desplegables o filtros de búsqueda.
        /// </remarks>
        /// <returns>Una lista de objetos que representan los Tipos de Requisito.</returns>
        /// <response code="200">La lista de Tipos de Requisitos fue obtenida exitosamente.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<TipoRequisito>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoRequisito>>> GetTiposRequisito()
        {
            return await _TipoDeRequisitoService.GetAllAsync();
        }

        /*
        // GET: api/TipoRequisito/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoRequisito>> GetTipoRequisito(Guid id)
        {
            var tipoRequisito = await _context.TiposRequisito.FindAsync(id);

            if (tipoRequisito == null)
            {
                return NotFound();
            }

            return tipoRequisito;
        }

        // PUT: api/TipoRequisito/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipoRequisito(Guid id, TipoRequisito tipoRequisito)
        {
            if (id != tipoRequisito.Id)
            {
                return BadRequest();
            }

            _context.Entry(tipoRequisito).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TipoRequisitoExists(id))
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

        // POST: api/TipoRequisito
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TipoRequisito>> PostTipoRequisito(TipoRequisito tipoRequisito)
        {
            _context.TiposRequisito.Add(tipoRequisito);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTipoRequisito", new { id = tipoRequisito.Id }, tipoRequisito);
        }

        // DELETE: api/TipoRequisito/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoRequisito(Guid id)
        {
            var tipoRequisito = await _context.TiposRequisito.FindAsync(id);
            if (tipoRequisito == null)
            {
                return NotFound();
            }

            _context.TiposRequisito.Remove(tipoRequisito);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TipoRequisitoExists(Guid id)
        {
            return _context.TiposRequisito.Any(e => e.Id == id);
        }
        */
    }
}
