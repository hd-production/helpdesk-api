using System;

namespace HdProduction.HelpDesk.Domain.Exceptions
{
  public class BusinessLogicException : ArgumentException
  {
    public BusinessLogicException(string message) : base(message)
    {
    }

    public BusinessLogicException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
  }
}