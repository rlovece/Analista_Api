using Analista.Models;
using Analista.Repositorios.Interfaces;
using Analista.Services.Interfaces;
using Analista.Utilidades.Enums;
using Microsoft.AspNetCore.Mvc;

namespace Analista.Services
{
    public class SubTipoRequisitoService : ISubTipoRequisitoService
    {
        private IUnidadDeTrabajo _UnidadDeTrabajo;

        public SubTipoRequisitoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _UnidadDeTrabajo = unidadDeTrabajo;
        }

        public async Task<SubTipoRequisito> CreateAsync(SubTipoRequisitoDTO entity)
        {
            // Verificar si ya existe un TipoRequisito con el mismo nombre
            var subTipRequisitoExistente = await _UnidadDeTrabajo._subTipoRequisitoRepositorio.GetByNombreAsync(entity.Nombre);

            if (subTipRequisitoExistente != null)
            {
                throw new Exception("Ya existe un SubTipo de Requisito con ese nombre.");
            }
            else
            {
                // Si no existe, proceder a crear el nuevo TipoRequisito
                var nuevoSubTipoRequisito = new SubTipoRequisito
                {
                    Id = Guid.NewGuid(),
                    Nombre = entity.Nombre,
                    Activo = true,
                    FechaCreacion = DateTime.UtcNow,
                    FechaModificacion = null
                };

                if (entity.IdTipoRequisito != null)
                {
                    nuevoSubTipoRequisito.IdTipoRequisito = entity.IdTipoRequisito.Value;
                }
                await _UnidadDeTrabajo._subTipoRequisitoRepositorio.AddAsync(nuevoSubTipoRequisito);
                await _UnidadDeTrabajo.GuardarCambiosAsync();

                return nuevoSubTipoRequisito;
            }
        }

        public async Task<ResultadoEliminacion> DeleteAsync(Guid id)
        {
            try
            {
                var subtipoAEliminar = await _UnidadDeTrabajo._subTipoRequisitoRepositorio.GetByIdAsync(id);
                if (subtipoAEliminar != null)
                {
                    if (subtipoAEliminar.Activo == false)
                    {
                        return ResultadoEliminacion.YaEliminado;
                    }
                    subtipoAEliminar.Activo = false;
                    subtipoAEliminar.FechaModificacion = DateTime.UtcNow;
                    _UnidadDeTrabajo._subTipoRequisitoRepositorio.Update(subtipoAEliminar);
                    await _UnidadDeTrabajo.GuardarCambiosAsync();
                    return ResultadoEliminacion.Exito;
                }
                return ResultadoEliminacion.NoEncontrado;
            }
            catch (Exception ex)
            {
                // Manejo de excepciones
                throw new Exception($"Error al eliminar el SubTipo de Requisito: {ex.Message}");
            }
        }

        public async Task<List<SubTipoRequisito>> GetAllAsync()
        {
            return await _UnidadDeTrabajo._subTipoRequisitoRepositorio.GetAllAsync();
        }

        public async Task<SubTipoRequisito?> GetByIdAsync(Guid id)
        {
            return await _UnidadDeTrabajo._subTipoRequisitoRepositorio.GetByIdAsync(id);
        }

        public async Task<bool> UpdateAsync(Guid id, SubTipoRequisitoDTO entity)
        {
            var subtipoBD = await _UnidadDeTrabajo._subTipoRequisitoRepositorio.GetByIdAsync(id);

            if (subtipoBD == null)
            {
                return false; // No se encontró el Tipo de Requisito a actualizar
            }

            subtipoBD.Nombre = entity.Nombre;
            subtipoBD.FechaModificacion = DateTime.UtcNow;

            _UnidadDeTrabajo._subTipoRequisitoRepositorio.Update(subtipoBD);
            await _UnidadDeTrabajo.GuardarCambiosAsync();
            return true; // Tipo de Requisito actualizado exitosamente
        }

        
    }
}
