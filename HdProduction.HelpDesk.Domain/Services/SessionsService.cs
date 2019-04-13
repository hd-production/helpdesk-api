using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Exceptions;

namespace HdProduction.HelpDesk.Domain.Services
{
  public class SessionsService : ISessionService
  {
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public SessionsService(IUserRepository userRepository, ITokenService tokenService)
    {
      _userRepository = userRepository;
      _tokenService = tokenService;
    }

    public async Task<(string jwtToken, string refreshToken)> AuthenticateAsync(string email, string pwd)
    {
      var user = await _userRepository.FindByEmail(email) ?? throw new EntityNotFoundException("User doesn't exist");
      var securityHelper = new SecurityHelper(user.PwdSalt);
      if (securityHelper.CheckPassword(pwd, user.PwdSalt))
      {
        throw new BusinessLogicException("Invalid creds");
      }
      var refreshToken = securityHelper.CreateRefreshToken();
      user.SetRefreshToken(refreshToken);

      await _userRepository.SaveAsync();

      return (_tokenService.CreateToken(user), refreshToken);
    }

    public async Task<(string jwtToken, string refreshToken)> RefreshSessionAsync(string refreshToken, long userId)
    {
      var user = await _userRepository.FindAsync(userId) 
                 ?? throw new EntityNotFoundException("User not found");
      if (user == null || user.RefreshToken != refreshToken)
      {
        throw new BusinessLogicException("Wrong refresh token");
      }

      var securityHelper = new SecurityHelper(user.PwdSalt);
      var newRefreshToken = securityHelper.CreateRefreshToken();
      user.SetRefreshToken(newRefreshToken);

      await _userRepository.SaveAsync();

      return (_tokenService.CreateToken(user), newRefreshToken);
    }

    public async Task SignOutAsync(long userId)
    {
      var user = await _userRepository.FindAsync(userId) ?? throw new EntityNotFoundException("User not found");
      user.SetRefreshToken(null);
      await _userRepository.SaveAsync();
    }
  }
}