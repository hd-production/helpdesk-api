using System;
using System.Net;
using System.Threading.Tasks;
using HdProduction.App.Common;
using HdProduction.HelpDesk.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace HdProduction.HelpDesk.Api.Configuration
{
  public class ErrorHandlingMiddleware : ErrorHandlingMiddlewareBase
  {
    public ErrorHandlingMiddleware(RequestDelegate next) : base(next)
    {
    }

    protected override Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
      string message;
      var statusCode = HttpStatusCode.InternalServerError;
      var exception = ex.GetBaseException();

      switch (exception)
      {
        case EntityNotFoundException _:
          statusCode = HttpStatusCode.NotFound;
          message = exception.Message;
          break;
        case BusinessLogicException _:
          statusCode = HttpStatusCode.BadRequest;
          message = exception.Message;
          break;
        case UnauthorizedAccessException _:
          statusCode = HttpStatusCode.Unauthorized;
          message = exception.Message;
          break;
        default:
          Logger.Error("Unknown exception", exception);
          message = "Oops. Something went wrong.";
          break;
      }

      var result = JsonConvert.SerializeObject(new {message});
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)statusCode;
      return context.Response.WriteAsync(result);
    }
  }
}