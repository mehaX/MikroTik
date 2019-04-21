using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MikroTik.Application.Exceptions;

namespace MikroTik.WebApi.Filters
{
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.ContentType = "application/json";
            if (context.Exception is ValidationException)
            {
                context.HttpContext.Response.StatusCode = (int) HttpStatusCode.BadRequest;
                context.Result = new JsonResult(((ValidationException)context.Exception).Failures);

                return;
            }

            var code = context.Exception is NotFoundException ?
                HttpStatusCode.NotFound :
                HttpStatusCode.InternalServerError;

            context.HttpContext.Response.StatusCode = (int) code;
            context.Result = new JsonResult(new
            {
                error = new[] { context.Exception.Message },
                stackTrace = context.Exception.StackTrace
            });
        }
    }
}
