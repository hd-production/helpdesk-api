using System;
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
        private readonly IEmailService _emailService;

        public UserService(IUserRepository userRepository, IUserSafeguard safeguard, IEmailService emailService)
        {
            _userRepository = userRepository;
            _safeguard = safeguard;
            _emailService = emailService;
        }

        public async Task<long> CreateAsync(string firstName, string lastName, string email, string role, long projectId)
        {
            await _safeguard.EnsureEmailAsync(email);
            // TODO _safeguard.EnsureName(lastName, firstName); etc.

            var password = GeneratePassword();
            var pwdHash = SecurityHelper.CreateMd5Hash(password);
            var pwdHelper = SecurityHelper.Create();
            var user = new User(email, firstName, lastName, role ?? string.Empty,
                pwdHelper.CreateSaltedPassword(pwdHash), pwdHelper.Salt);
            _userRepository.Add(user);

            await _emailService.SendMailInvitationAsync(email, password);
            await _userRepository.SaveAsync();
            return user.Id;
        }

        public async Task<User> FindAsync(long id)
        {
            return await _userRepository.FindAsync(id) 
                   ?? throw new EntityNotFoundException("User with such id not found.");
        }

        private static string GeneratePassword()
        {
            return Guid.NewGuid().ToString("N");
        }
    }
}