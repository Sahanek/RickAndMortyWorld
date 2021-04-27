using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace API.Middleware
{
    /// <summary>
    /// Middleware przechwytujący błędy dla ładniejszego wyświetlania
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        /// <summary>
        ///  Przechwytuje i przetwarza błędy w przystępnej formie.
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (WebException ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, WebException exception)
        {
            context.Response.ContentType = "application/json";

            using (WebResponse response = exception.Response)
            {
                string ErrorMessage = null;
                HttpWebResponse httpWebResponse = (HttpWebResponse)response;

                using (Stream data = response.GetResponseStream())
                using (var reader = new StreamReader(data))
                {
                    ErrorMessage = reader.ReadToEnd();
                }

                return context.Response.WriteAsync(new Errors.ApiError()
                {
                    StatusCode = (int)httpWebResponse.StatusCode,
                    Message = ErrorMessage
                }.ToString());

            }

        }

    }
}
