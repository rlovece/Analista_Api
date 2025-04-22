
using Microsoft.AspNetCore.Mvc;
using Analista.Models;
using Analista.Services.Interfaces;
using Analista.Enums;

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

        // Helper para crear respuestas estandarizadas
        private IActionResult Respuesta<T>(int status, string mensaje, T data)
        {
            return StatusCode(status, new ApiResponse<T>
            {
                Status = status,
                Mensaje = mensaje,
                Data = data
            });
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
        [ProducesResponseType(typeof(ApiResponse<List<TipoRequisito>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTiposRequisito()
        {
            try
            {
                var data = await _TipoDeRequisitoService.GetAllAsync();
                return Respuesta<List<TipoRequisito>>(200, "Lista obtenida exitosamente", data);
            }
            catch (Exception ex)
            {
                return Respuesta<string>(500, $"Error interno del servidor: {ex.Message}", null);
            }
            
        }


        /// <summary>
        /// Obtiene un Tipo de Requisito según el id.
        /// </summary>
        /// <remarks>
        /// Este endpoint retorna Tipo de Requisito según el id.
        /// </remarks>
        /// <returns>Un objeto que representa un Tipo de Requisito.</returns>
        /// <response code="200">El Tipo de Requisito fue obtenido exitosamente.</response>
        /// <response code="404">Tipo de Requisito no encontrado</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<TipoRequisito>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetTipoRequisito(Guid id)
        {

            try
            {
                var tipoRequisito = await _TipoDeRequisitoService.GetByIdAsync(id);

                return Respuesta<TipoRequisito>(200, "Tipo de requisito no encontrado", tipoRequisito);
            } catch (Exception ex)
            {
                return Respuesta<String>(500, $"Error interno del servidor: {ex.Message}", null);
            }
            
        }


        // PATCH: api/TipoRequisito/5
        /// <summary>
        /// Modifica un Tipo de Requisito según el id.
        /// </summary>
        /// <remarks>
        /// Este endpoint permite modificar un Tipo de Requisito existente en el sistema. Los datos posibles de modificar son: Nombre e indicador de estado Activo.
        /// </remarks>
        /// <returns>Se retorna mensaje de éxito o exceptión </returns>
        /// <response code="200">El Tipo de Requisito actualizado exitosamente.</response>
        /// <response code="404">Id no encontrado</response>
        /// <response code="400">Tipo de Requisito no válido</response>
        /// <response code="500">Error interno del servidor.</response>
        /// 
        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchTipoRequisito(Guid id,[FromBody] TipoRequisitoDTO tipoRequisito)
        {

            if (id != tipoRequisito.Id)
            {
                return  Respuesta<string>(404, "Id no corresponde", null);
            }

            // Actualizar el Tipo de Requisito
            try

            {
                var actualizado = await _TipoDeRequisitoService.UpdateAsync(id, tipoRequisito);
                if (!actualizado)
                {
                    return Respuesta<string>(404, "Tipo de requisito no encontrado", null);
                }
                return Respuesta<string>(200, "Tipo de requisito actualizado exitosamente", null);
                
            }catch (Exception ex)
            {
                return Respuesta<string>(500, $"Error interno del servidor: {ex.Message}", null);
            }
        }


        // POST: api/TipoRequisito
        /// <summary>
        /// Crea un Tipo de Requisito
        /// </summary>
        /// <remarks>
        /// Este endpoint permite la creación de un nuevo Tipo de Requisito
        /// </remarks>
        /// <returns>Se retorna mensaje de éxito o exceptión </returns>
        /// <response code="201">El Tipo de Requisito creado exitosamente.</response>
        /// <response code="400">Tipo de Requisito no válido</response>
        /// <response code="500">Error interno del servidor.</response>
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<TipoRequisito>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostTipoRequisito(TipoRequisitoDTO tipoRequisito)
        {
            try
            {
                TipoRequisito nuevoTipo = await _TipoDeRequisitoService.CreateAsync(tipoRequisito);

                return Respuesta<TipoRequisito>(201, "Tipo de requisito creado exitosamente", nuevoTipo);
            }
            catch (Exception ex)
            {
                if (ex.Equals("Ya existe un Tipo de Requisito con ese nombre."))
                {
                    Console.WriteLine(ex);
                    return Respuesta<string>(400, "Ya existe un Tipo de Requisito con ese nombre.", null);
                }
                return Respuesta<string>(500, $"Error interno del servidor: {ex.Message}", null);
            }
            
        }


        // DELETE: api/TipoRequisito/5
        /// <summary>
        /// Elimina lógicamente un Tipo de Requisito según el id.
        /// </summary>
        /// <remarks>
        /// Este endpoint permite la eliminación lógica de un nuevo Tipo de Requisito por su id, siempre que éxista.
        /// </remarks>
        /// <returns>Se retorna mensaje de éxito o exceptión </returns>
        /// <response code="200">El Tipo de Requisito eliminado exitosamente.</response>
        /// <response code="404">Tipo de Requisito no encontrado</response>
        /// <response code="410">Tipo de Requisito ya eliminado</response>
        /// <response code="500">Error interno del servidor.</response>
        /// 
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status410Gone)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipoRequisito(Guid id)
        {
            try
            {
                if (await _TipoDeRequisitoService.DeleteAsync(id) == ResultadoEliminacion.Exito)
                {
                    return Respuesta<string>(200, "Tipo de requisito eliminado exitosamente", null);
                }
                else if (await _TipoDeRequisitoService.DeleteAsync(id) == ResultadoEliminacion.NoEncontrado)
                {
                    return Respuesta<string>(404, "Tipo de requisito no encontrado", null);
                }
                else 
                {
                    return Respuesta<string>(410, "Tipo de requisito ya eliminado", null);
                }

            }catch(Exception ex)
            {
                                                                       
                return Respuesta<string>(500, $"Error interno del servidor: {ex.Message}", null);
            }
        }
        
    }
}
