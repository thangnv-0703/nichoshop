using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NichoShop.Application.Exceptions;

namespace NichoShop.Application.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //TODO:  Logging 

            context.ExceptionHandled = true;

            switch (context.Exception)
            {
                case NotFoundException notFoundException:
                    context.Result = new ObjectResult(notFoundException)
                    {
                        StatusCode = 404,
                        Value = notFoundException.Message
                    };
                    break;
                case UnauthorizedAccessException unauthorizedAccessException:
                    context.Result = new ObjectResult(unauthorizedAccessException)
                    {
                        StatusCode = 401
                    };
                    break;

                case DomainException domainException:
                    context.Result = new ObjectResult(domainException)
                    {
                        StatusCode = 422,
                        Value = domainException
                    };
                    break;
                default:
                    string msg = "Exception";
#if DEBUG
                    msg = context.Exception.ToString();
#endif
                    context.Result = new ObjectResult(context.Exception)
                    {
                        StatusCode = 500,
                        Value = msg
                    };
                    break;
            }
        }
    }
}
