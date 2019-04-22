using System;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using HdProduction.App.Common;
using HdProduction.HelpDesk.Domain.Exceptions;
using log4net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace HdProduction.HelpDesk.Api.Configuration
{
  public class ErrorHandlingMiddleware : ErrorHandlingMiddlewareBase
  {
    public ErrorHandlingMiddleware(RequestDelegate next) : base(next)
    {
    }

    protected override Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
      string message;
      var statusCode = HttpStatusCode.InternalServerError;

      switch (exception)
      {
        // TODO normal filters
        case EntityNotFoundException _:
          statusCode = HttpStatusCode.NotFound;
          message = exception.Message;
          break;
        case ApplicationException _:
          statusCode = HttpStatusCode.BadRequest;
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