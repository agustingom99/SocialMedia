using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SocialMedia_Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SocialMedia.Infrastructure.Filters
{
    public class GlobalExceptionFilters : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception.GetType() == typeof(BussinesExceptions))
            {
                var exception = (BussinesExceptions)context.Exception;
                var validation = new
                {
                    status = 400,
                    title = "bad request",
                    message = exception.Message
                };
                var json = new
                {
                    error = new[] { validation }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
        }
    }
}
