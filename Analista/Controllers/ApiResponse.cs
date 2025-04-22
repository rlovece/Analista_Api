namespace Analista.Controllers
{
    /// <summary>
    /// Representa una Respuesta estandar de la Api
    /// </summary>
    /// <typeparam name="T">Tipo de dato devuelto en la respuesta</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Código de estado HTTP
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// Mensaje de respuesta
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Datos de la respuesta
        /// </summary>
        public T Data { get; set; }

    }
}
