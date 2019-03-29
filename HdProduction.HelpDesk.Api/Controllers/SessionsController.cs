using System.Threading.Tasks;
using HdProduction.App.Common.Auth;
using HdProduction.HelpDesk.Api.Extensions;
using HdProduction.HelpDesk.Api.Models.Sessions;
using HdProduction.HelpDesk.Domain.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HdProduction.HelpDesk.Api.Controllers
{
  [ApiController, ApiVersion("0")]
  [Route("v{version:apiVersion}/sessions")]
  public class SessionsController : ControllerBase
  {
//    private readonly ISessionService _sessionService;
//
//    public SessionsController(ISessionService sessionService)
//    {
//      _sessionService = sessionService;
//    }
//
//    [HttpPost("")]
//    public async Task<SessionResponseModel> Authenticate([FromBody] AuthenticateRequestModel requestModel)
//    {
//      var (token, refreshToken) = await _sessionService.AuthenticateAsync(requestModel.Email, requestModel.PwdHash);
//      return new SessionResponseModel
//      {
//        Token = token,
//        RefreshToken = refreshToken
//      };
//    }
//
//    [HttpPut("refresh"), Authorize(AuthenticationSchemes = JwtDefaults.AuthenticationSchemeIgnoreExpiration)]
//    public async Task<SessionResponseModel> Refresh([FromBody] RefreshSessionRequestModel requestModel)
//    {
//      var (token, refreshToken) = await _sessionService.RefreshSessionAsync(requestModel.RefreshToken, User.GetId());
//      return new SessionResponseModel
//      {
//        Token = token,
//        RefreshToken = refreshToken
//      };
//    }
//
//    [HttpDelete(""), Authorize]
//    public Task SignOut() => _sessionService.SignOutAsync(User.GetId());
  }
}