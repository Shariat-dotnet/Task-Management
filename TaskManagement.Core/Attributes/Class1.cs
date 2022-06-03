using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using TaskManagement.Core.Models;

namespace TaskManagement.Core.Attributes;

public class ValidateRequestAttribute : ActionFilterAttribute
{
    /// <summary>
    /// ActionFilterAttribute extension to catch errors and status code  OnActionExecuting
    /// </summary>
    public ValidateRequestAttribute()
    {

    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.ModelState.IsValid)
        {

            var errors = context.ModelState.Where(v => v.Value?.Errors.Count > 0)
                .ToDictionary(
                    kvp => $"{char.ToLower(kvp.Key[0])}{kvp.Key.Substring(1)}",
                    kvp => kvp.Value?.Errors.FirstOrDefault()?.ErrorMessage
                );
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
            context.Result = new UnprocessableEntityObjectResult(new JsonResponse
            {
                StatusCode = StatusCodes.Status422UnprocessableEntity,
                Data = errors
            });
            return;
        }
    }
}
