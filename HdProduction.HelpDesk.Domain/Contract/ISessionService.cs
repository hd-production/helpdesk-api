using System.Threading.Tasks;

namespace HdProduction.HelpDesk.Domain.Contract
{
  public interface ISessionService
  {
    Task<(string jwtToken, string refreshToken)> AuthenticateAsync(string email, string pwd);
    Task<(string jwtToken, string refreshToken)> RefreshSessionAsync(string refreshToken, long userId);
    Task SignOutAsync(long userId);
  }
}