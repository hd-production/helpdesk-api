using System.Threading.Tasks;
using AutoMapper;
using HdProduction.HelpDesk.Api.Models.Users;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HdProduction.HelpDesk.Api.Controllers
{
    [ApiController, ApiVersion("0")]
    [Route("users")]
    public class UsersController
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
                requestModel.Email,
                requestModel.PwdHash
            );
            var user = await _userService.FindAsync(userId);
            return _mapper.Map<User, UserResponseModel>(user);
        }

        [HttpGet("{id}")]
        public async Task<UserResponseModel> Find(long id)
        {
            var user = await _userService.FindAsync(id);
            return _mapper.Map<User, UserResponseModel>(user);
        }
    }
}