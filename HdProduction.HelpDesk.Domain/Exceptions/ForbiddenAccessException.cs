using System;

namespace HdProduction.HelpDesk.Domain.Exceptions
{
  public class ForbiddenAccessException : ArgumentException
  {
    public ForbiddenAccessException(string message) : base(message)
    {
    }

    public ForbiddenAccessException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
  }
}