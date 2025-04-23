using Analista.DTOs.Response;
using Microsoft.AspNetCore.Mvc;

namespace Analista.Utilidades.Helpers
{
    public static class ApiResponseHelper
    {
        public static IActionResult CrearRespuesta<T>(int status, string mensaje, T? data)
        {
            return new ObjectResult(new ApiResponse<T>
            {
                Status = status,
                Mensaje = mensaje,
                Data = data 
            })
            {
                StatusCode = status
            };
        }
    }
}
