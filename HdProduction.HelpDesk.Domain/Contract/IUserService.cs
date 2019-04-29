using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Domain.Contract
{
    public interface IUserService
    {
        Task<User> CreateAsync(string firstName, string lastName, string email, string pwdHash);

        Task<User> Find(long id);
    }
}