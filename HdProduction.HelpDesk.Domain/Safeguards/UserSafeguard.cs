using System.Net.Mail;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Exceptions;

namespace HdProduction.HelpDesk.Domain.Safeguards
{
    public class UserSafeguard : IUserSafeguard
    {
        private readonly IUserRepository _userRepository;

        public UserSafeguard(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EnsureEmailAsync(string email)
        {
            if (!IsEmailValid(email))
            {
                throw ExceptionsHelper.WrongFormat(nameof(email));
            }

            if (await _userRepository.FindByEmailAsync(email) != null)
            {
                throw ExceptionsHelper.EntityAlreadyExists("User", nameof(email));
            }
        }
        
        private bool IsEmailValid(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return mailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}