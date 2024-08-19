using Application.Common.Exceptions;
using Domain.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ApplicationException = System.ApplicationException;

namespace RestAPI.Common;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        ApiError apiError;
        int statusCode;
        Console.Out.Write(context.Exception);
        switch (context.Exception)
        {
            case NotFoundException notFoundException:
                apiError = new ApiError(notFoundException.Message);
                statusCode = 404; // Not Found
                break;

            case ValidationException validationException:
                apiError = new ApiError("Validation failed", validationException.Message);
                statusCode = 422; // Unprocessable Entity
                break;

            case DomainException domainException:
                apiError = new ApiError(domainException.Message);
                statusCode = 400; // Bad Request
                break;

            case ApplicationException applicationException:
                apiError = new ApiError(applicationException.Message);
                statusCode = 400; 
                break;

            default:
                apiError = new ApiError("An unexpected error occurred.");
                statusCode = 500; // Internal Server Error
                break;
        }

        context.Result = new JsonResult(apiError)
        {
            StatusCode = statusCode
        };

        context.ExceptionHandled = true; // Mark the exception as handled   
    }
}
