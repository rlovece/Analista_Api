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
using Analista.Utilidades.Helpers;
using Analista.DTOs.Response;
using Analista.Utilidades.Enums;

namespace Analista.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTipoRequisitosController : ControllerBase
    {
        private readonly ISubTipoRequisitoService _subTipoRequisitoService;

        public SubTipoRequisitosController(ISubTipoRequisitoService subTipoRequisitoService)
        {
            _subTipoRequisitoService = subTipoRequisitoService;
        }

        // GET: api/SubTipoRequisitos
        /// Obtiene todos los sub tipos de requisito disponibles.
        /// </summary>
        /// <remarks>
        /// Este endpoint retorna una lista con todos los sub tipos de requisito registrados en el sistema.
        /// </remarks>
        /// <returns>Una lista de objetos que representan los SubTipos de Requisito.</returns>
        /// <response code="200">La lista de SubTipos de Requisitos fue obtenida exitosamente.</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<List<SubTipoRequisito>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSubTiposRequisito()
        {

            try
            {
                var data = await _subTipoRequisitoService.GetAllAsync();
                return ApiResponseHelper.CrearRespuesta(200, "Lista obtenida exitosamente", data);
            }
            catch (Exception ex)
            {
                return ApiResponseHelper.CrearRespuesta(500, $"Error interno del servidor: {ex.Message}", (String?)null);
            }
        }

        // GET: api/SubTipoRequisitos/5
        /// <summary>
        /// Obtiene un SubTipo de Requisito según el id.
        /// </summary>
        /// <remarks>
        /// Este endpoint retorna SubTipo de Requisito según el id.
        /// </remarks>
        /// <returns>Un objeto que representa un Tipo de Requisito.</returns>
        /// <response code="200">El SubTipo de Requisito fue obtenido exitosamente.</response>
        /// <response code="404">SubTipo de Requisito no encontrado</response>
        /// <response code="500">Error interno del servidor.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<SubTipoRequisito>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetSubTipoRequisito(Guid id)
        {
            try
            {
                var subTipo = await _subTipoRequisitoService.GetByIdAsync(id);

                return ApiResponseHelper.CrearRespuesta(200, "Tipo de requisito no encontrado", subTipo);
            }
            catch (Exception ex)
            {
                return ApiResponseHelper.CrearRespuesta<string>(500, $"Error interno del servidor: {ex.Message}", null);
            }
        }

        // PATCH: api/SubTipoRequisito/5
        /// <summary>
        /// Modifica un SubTipo de Requisito según el id.
        /// </summary>
        /// <remarks>
        /// Este endpoint permite modificar el nombre un SubTipo de Requisito existente en el sistema.
        /// </remarks>
        /// <returns>Se retorna mensaje de éxito o exceptión </returns>
        /// <response code="200">El SubTipo de Requisito actualizado exitosamente.</response>
        /// <response code="404">Id no encontrado</response>
        /// <response code="400">SubTipo de Requisito no válido</response>
        /// <response code="500">Error interno del servidor.</response>
        /// 
        [HttpPatch("{id}")]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PatchSubTipoRequisito(Guid id, [FromBody] SubTipoRequisitoDTO subTipo)
        {

            if (id != subTipo.Id)
            {
                return ApiResponseHelper.CrearRespuesta<string>(404, "Id no corresponde", null);
            }

            // Actualizar el Tipo de Requisito
            try

            {
                var actualizado = await _subTipoRequisitoService.UpdateAsync(id, subTipo);
                if (!actualizado)
                {
                    return ApiResponseHelper.CrearRespuesta<string>(404, "Tipo de requisito no encontrado", null);
                }
                return ApiResponseHelper.CrearRespuesta<string>(200, "Tipo de requisito actualizado exitosamente", null);

            }
            catch (Exception ex)
            {
                return ApiResponseHelper.CrearRespuesta<string>(500, $"Error interno del servidor: {ex.Message}", null);
            }
        }


        // POST: api/SubTipoRequisito
        /// <summary>
        /// Crea un SubTipo de Requisito
        /// </summary>
        /// <remarks>
        /// Este endpoint permite la creación de un nuevo SubTipo de Requisito
        /// </remarks>
        /// <returns>Se retorna mensaje de éxito o exceptión </returns>
        /// <response code="201">El SubTipo de Requisito creado exitosamente.</response>
        /// <response code="400">SubTipo de Requisito no válido</response>
        /// <response code="500">Error interno del servidor.</response>
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<SubTipoRequisito>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> PostSubTipoRequisito(SubTipoRequisitoDTO subTipo)
        {
            try
            {
                SubTipoRequisito nuevoSubTipo = await _subTipoRequisitoService.CreateAsync(subTipo);

                return ApiResponseHelper.CrearRespuesta(201, "Tipo de requisito creado exitosamente", nuevoSubTipo);
            }
            catch (Exception ex)
            {
                if (ex.Equals("Ya existe un SubTipo de Requisito con ese nombre."))
                {
                    Console.WriteLine(ex);
                    return ApiResponseHelper.CrearRespuesta<string>(400, "Ya existe un SubTipo de Requisito con ese nombre.", null);
                }
                return ApiResponseHelper.CrearRespuesta<string>(500, $"Error interno del servidor: {ex.Message}", null);
            }

        }


        // DELETE: api/SubTipoRequisito/5
        /// <summary>
        /// Elimina lógicamente un SubTipo de Requisito según el id.
        /// </summary>
        /// <remarks>
        /// Este endpoint permite la eliminación lógica de un nuevo SubTipo de Requisito por su id, siempre que éxista.
        /// </remarks>
        /// <returns>Se retorna mensaje de éxito o exceptión </returns>
        /// <response code="200">El SubTipo de Requisito eliminado exitosamente.</response>
        /// <response code="404">SubTipo de Requisito no encontrado</response>
        /// <response code="410">SubTipo de Requisito ya eliminado</response>
        /// <response code="500">Error interno del servidor.</response>
        /// 
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status410Gone)]
        [ProducesResponseType(typeof(ApiResponse<string>), StatusCodes.Status500InternalServerError)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubTipoRequisito(Guid id)
        {
            try
            {
                if (await _subTipoRequisitoService.DeleteAsync(id) == ResultadoEliminacion.Exito)
                {
                    return ApiResponseHelper.CrearRespuesta<string>(200, "SubTipo de requisito eliminado exitosamente", null);
                }
                else if (await _subTipoRequisitoService.DeleteAsync(id) == ResultadoEliminacion.NoEncontrado)
                {
                    return ApiResponseHelper.CrearRespuesta<string>(404, "SubTipo de requisito no encontrado", null);
                }
                else
                {
                    return ApiResponseHelper.CrearRespuesta<string>(410, "SubTipo de requisito ya eliminado", null);
                }

            }
            catch (Exception ex)
            {

                return ApiResponseHelper.CrearRespuesta<string>(500, $"Error interno del servidor: {ex.Message}", null);
            }
        }
    }
}
