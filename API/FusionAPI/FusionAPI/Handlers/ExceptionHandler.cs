using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAPI.Handlers
{
    public static class ExceptionHandler
    {

        public static void HandleException(ExceptionContext context)
        {
            //TODO: exception handlling
            // Log exception
            // handle exception and return new response code

            var errorCode = 500;
            var errorText = "Un handled exception occurred, please contact administrator.";

            var bytes = Encoding.ASCII.GetBytes(errorText);

            context.HttpContext.Response.StatusCode = errorCode;
            context.HttpContext.Response.Body.Write(bytes, 0, bytes.Length - 1);
            context.ExceptionHandled = true;
        }

    }
}
