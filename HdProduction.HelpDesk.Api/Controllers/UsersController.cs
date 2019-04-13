using System.Threading.Tasks;
using HdProduction.HelpDesk.Api.Models.Users;
using HdProduction.HelpDesk.Domain.Contract;
using Microsoft.AspNetCore.Mvc;

namespace HdProduction.HelpDesk.Api.Controllers
{
    [ApiController, ApiVersion("0")]
    [Route("users")]
    public class UsersController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("")]
        public Task Create(UserRequestModel requestModel)
        {
            return _userService.CreateAsync(requestModel.Email, requestModel.PwdHash);
        }
    }
}