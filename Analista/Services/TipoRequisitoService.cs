using Analista.Enums;
using Analista.Models;
using Analista.Repositorios.Interfaces;
using Analista.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Analista.Services
{
    public class TipoRequisitoService : ITipoRequisitoService
    {
        private IUnidadDeTrabajo _UnidadDeTrabajo;

        public TipoRequisitoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _UnidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<TipoRequisito> CreateAsync(TipoRequisitoDTO entity)
        {
            // Verificar si ya existe un TipoRequisito con el mismo nombre
            var tipoRequisitoExistente = await _UnidadDeTrabajo._TipoRequisitoRepositorio.GetByNombreAsync(entity.Nombre);

            if (tipoRequisitoExistente != null)
            {
                throw new Exception("Ya existe un Tipo de Requisito con ese nombre.");
            }

            // Si no existe, proceder a crear el nuevo TipoRequisito
            var nuevoTipoRequisito = new TipoRequisito
            {
                Id = Guid.NewGuid(),
                Nombre = entity.Nombre,
                Activo = entity.Activo,
                FechaCreacion = DateTime.UtcNow,
                FechaModificacion = null
            };

            await _UnidadDeTrabajo._TipoRequisitoRepositorio.AddAsync(nuevoTipoRequisito);
            await _UnidadDeTrabajo.GuardarCambiosAsync();

            return nuevoTipoRequisito;

        }

        public async Task<ResultadoEliminacion> DeleteAsync(Guid id)
        {
            try
            {
                var tipoAEliminar = await _UnidadDeTrabajo._TipoRequisitoRepositorio.GetByIdAsync(id);
                if (tipoAEliminar != null)
                {
                    if (tipoAEliminar.Activo == false)
                    {
                        return ResultadoEliminacion.YaEliminado;
                    }
                    tipoAEliminar.Activo = false;
                    tipoAEliminar.FechaModificacion = DateTime.UtcNow;
                    _UnidadDeTrabajo._TipoRequisitoRepositorio.Update(tipoAEliminar);
                    await _UnidadDeTrabajo.GuardarCambiosAsync();
                    return ResultadoEliminacion.Exito;
                }
                return ResultadoEliminacion.NoEncontrado;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception($"Error al eliminar el Tipo de Requisito: {ex.Message}");
            }
        }

        public async Task<List<TipoRequisito>> GetAllAsync()
        {
            return await _UnidadDeTrabajo._TipoRequisitoRepositorio.GetAllAsync();
        }

        public async Task<TipoRequisito?> GetByIdAsync(Guid id)
        {
            return await _UnidadDeTrabajo._TipoRequisitoRepositorio.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Guid id, TipoRequisitoDTO entity)
        {
            var tipoBD = await _UnidadDeTrabajo._TipoRequisitoRepositorio.GetByIdAsync(id);

            if (tipoBD == null)
            {
                return false; // No se encontró el Tipo de Requisito a actualizar
            }

            tipoBD.Nombre = entity.Nombre;

            tipoBD.FechaModificacion = DateTime.UtcNow;

            _UnidadDeTrabajo._TipoRequisitoRepositorio.Update(tipoBD);
            await _UnidadDeTrabajo.GuardarCambiosAsync();
            return true; // Tipo de Requisito actualizado exitosamente
        }

        
    }
}
