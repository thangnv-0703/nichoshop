using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NichoShop.Application.Models;

namespace NichoShop.Application.Middleware;

public class ApiResponseFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Result is ObjectResult objectResult)
        {
            var response = new ApiResponse
            {
                Status = objectResult.StatusCode >= 200 && objectResult.StatusCode < 300,
                Message = "Request processed successfully.",
                Data = objectResult.Value
            };

            context.Result = new ObjectResult(response)
            {
                StatusCode = objectResult.StatusCode
            };
        }
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
        // Thực thi trước khi Action chạy
    }
}
