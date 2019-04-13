using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using HdProduction.HelpDesk.Domain.Services;

namespace HdProduction.HelpDesk.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task CreateAsync(string email, string pwdHash)
        {
            var pwdHelper = SecurityHelper.Create();
            _userRepository.Add(new User(email, "abc", "cde", "", 
                pwdHelper.CreateSaltedPassword(pwdHash), pwdHelper.Salt));
            return _userRepository.SaveAsync();
        }
    }
}