using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Errors
{
    /// <summary>
    /// Klasa przetwarzająca błędy do ich lepszego wyświetlania.
    /// </summary>
    public class ApiError
    {
        /// <summary>
        /// Kod błędu
        /// </summary>
        public int StatusCode { get; set; }
        /// <summary>
        /// Wiadomość
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// pusty konstruktor
        /// </summary>
        public ApiError()
        {
        }

        /// <summary>
        /// przypisuje wiadomość lub wiadomość odpowiednią dla błędu jeśli takiej nie ma
        /// </summary>
        /// <param name="statusCode"></param>
        /// <param name="message"></param>
        public ApiError(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetErrorMessage(statusCode);
        }

        private string GetErrorMessage(int errorCode)
        {
            return errorCode switch
            {
                400 => "Error: Bad Request",
                401 => "Error: Unauthorized - You are not authorized",
                403 => "Error: Forbidden - You lack permission to access this resource",
                404 => "Error: Not found - The resource you are searching for cannot be found",
                405 => "Error: Method not allowed: Maybe you are using GET equest instead of f. ex. POST",
                408 => "Error: Request Timeout - It took you too long to make a request",

                _ => null
            };
        }
        /// <summary>
        /// Serializuje obiekt na jsona.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
