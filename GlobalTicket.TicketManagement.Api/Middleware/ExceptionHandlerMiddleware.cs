using GlobalTicket.TicketManagement.Application.Exceptions;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace GlobalTicket.TicketManagement.Api.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _requestDelegate;

        public ExceptionHandlerMiddleware(RequestDelegate requestDelegate)
        {
            _requestDelegate = requestDelegate;
        }

        public async Task Invoke(HttpContext context) 
        {
            try
            {
               await _requestDelegate(context);
            }
            catch (Exception ex)
            {
                
                await ConvertException(context, ex);
            }
        }

        private Task ConvertException(HttpContext httpContext, Exception ex)
        {
            HttpStatusCode httpStatusCode = HttpStatusCode.InternalServerError;

            httpContext.Response.ContentType = "application/json";

            var result = string.Empty;

            switch (ex)
            {
                case ValidationException validationException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = JsonSerializer.Serialize(validationException.ValdationErrors);
                    break;
                case BadRequestException badRequestException:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    result = badRequestException.Message;
                    break;
                case NotFoundException:
                    httpStatusCode = HttpStatusCode.NotFound;
                    break;
                case Exception:
                    httpStatusCode = HttpStatusCode.BadRequest;
                    break;
                
            }

            httpContext.Response.StatusCode = (int)httpStatusCode;

            if (result == string.Empty)
            {

                result = JsonSerializer.Serialize(new { error = ex.Message });
                // new { error = ex.Message } is called an anonymous type
            }

            return httpContext.Response.WriteAsync(result);
        }
    }
}
