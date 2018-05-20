using FusionAPI.Handlers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FusionAPI.Filters
{

    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public CustomExceptionFilter()
        {
        }


        //
        public override void OnException(ExceptionContext context)
        {


           
            ExceptionHandler.HandleException(context);
           



            return;
        }
    }
}
