using System.Threading.Tasks;
using AutoMapper;
using HdProduction.App.Common.Auth;
using HdProduction.HelpDesk.Api.Extensions;
using HdProduction.HelpDesk.Api.Models.Users;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HdProduction.HelpDesk.Api.Controllers
{
    [ApiController, ApiVersion("0")]
    [Route("users")]
    public class UsersController: ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost("")]
        public async Task<UserResponseModel> Create(UserRequestModel requestModel)
        {
            var userId = await _userService.CreateAsync(
                requestModel.FirstName,
                requestModel.LastName,
                requestModel.Email
            );
            return await Find(userId);
        }

        [HttpGet("{id}"), Authorize]
        public async Task<UserResponseModel> Find(long id)
        {
            var user = await _userService.FindAsync(id);
            return _mapper.Map<User, UserResponseModel>(user);
        }

        [HttpGet("me"), Authorize]
        public async Task<UserResponseModel> FindMe()
        {
            long userId = User.GetId();
            return await Find(userId);
        }
    }
}