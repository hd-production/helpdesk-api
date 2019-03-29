using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;

namespace HdProduction.HelpDesk.Domain.Services
{
  public class SessionsService : ISessionService
  {
    private readonly IUserRepository _userRepository;

    public SessionsService(IUserRepository userRepository)
    {
      _userRepository = userRepository;
    }

    public Task<(string jwtToken, string refreshToken)> AuthenticateAsync(string email, string pwd)
    {
      throw new System.NotImplementedException();
    }

    public Task<(string jwtToken, string refreshToken)> RefreshSessionAsync(string refreshToken, long userId)
    {
      throw new System.NotImplementedException();
    }

    public Task SignOutAsync(long userId)
    {
      throw new System.NotImplementedException();
    }
  }
}