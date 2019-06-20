using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using HdProduction.HelpDesk.Domain.Exceptions;
using HdProduction.HelpDesk.Domain.Services;

namespace HdProduction.HelpDesk.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserSafeguard _safeguard;

        public UserService(IUserRepository userRepository, IUserSafeguard safeguard)
        {
            _userRepository = userRepository;
            _safeguard = safeguard;
        }

        public async Task<long> CreateAsync(string firstName, string lastName, string email, string pwdHash)
        {
            await _safeguard.EnsureEmailAsync(email);
            // TODO _safeguard.EnsureName(lastName, firstName); etc.

            var pwdHelper = SecurityHelper.Create();
            var user = new User(email, firstName, lastName, "",
                pwdHelper.CreateSaltedPassword(pwdHash), pwdHelper.Salt);
            _userRepository.Add(user);
            await _userRepository.SaveAsync();
            return user.Id;
        }

        public async Task<User> FindAsync(long id)
        {
            return await _userRepository.FindAsync(id) 
                   ?? throw new EntityNotFoundException("User with such id not found.");
        }
    }
}