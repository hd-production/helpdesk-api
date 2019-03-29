using System;

namespace HdProduction.HelpDesk.Domain.Exceptions
{
  public class EntityNotFoundException : BusinessLogicException
  {
    public EntityNotFoundException(string message) : base(message)
    {
    }

    public EntityNotFoundException(string message, Exception innerException)
      : base(message, innerException)
    {
    }
  }
}