using Application.Exceptions;
using Application.Interfaces;
using Application.Services;
using System.Net;
using System.Text.Json;

namespace API.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            string message = "Ocorreu um erro interno, conte o administrador.";
            HttpStatusCode status = HttpStatusCode.InternalServerError;

            if (exception is ApiException)
            {
                status = ((ApiException)exception).Status;
                message = exception.Message;
            }

            return ResponseService.GetPatterResponse(context, status, message);
        }
    }
}
