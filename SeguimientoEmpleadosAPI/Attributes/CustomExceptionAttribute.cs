using Dtos.Commons;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Resources.UtilsExecptions;
using System.Net;

namespace SeguimientoEmpleadosAPI.Attributes
{
    public class CustomExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var typeException = context.Exception.GetType();
            var response = new ResponseDto<string>
            {
                Ok = false,
                Mesage = "Error",
            };
            int statusCode = 0;
            if (typeException == typeof(UnauthorizedAccessException))
            {
                response.MesageError = context.Exception.Message;
                statusCode = (int)HttpStatusCode.Unauthorized;
            }
            else if (typeException == typeof(BusinessException))
            {
                response.MesageError = context.Exception.Message;
                statusCode = (int)HttpStatusCode.Ambiguous;
            }
            else if (typeException == typeof(CustomException))
            {
                response.MesageError = context.Exception.Message;
                statusCode = (int)HttpStatusCode.BadRequest;
            }
            else if(typeException == typeof(DbUpdateException)){
                response.MesageError = context.Exception.Message;
                statusCode = (int)HttpStatusCode.Conflict;
            }
            else
            {
                response.MesageError = context.Exception.Message;
                statusCode = (int)HttpStatusCode.InternalServerError;
            }
            context.ExceptionHandled = true;
            context.HttpContext.Response.ContentType = "application/json";
            context.HttpContext.Response.StatusCode = statusCode;
            context.HttpContext.Response.WriteAsJsonAsync(response);
            base.OnException(context);
        }
    }
}
