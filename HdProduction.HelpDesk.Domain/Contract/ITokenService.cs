using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Domain.Contract
{
  public interface ITokenService
  {
    string CreateToken(User user);
  }
}