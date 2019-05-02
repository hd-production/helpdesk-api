using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Domain.Contract
{
    public interface IUserService
    {
        Task<long> CreateAsync(string firstName, string lastName, string email, string pwdHash);

        Task<User> FindAsync(long id);
    }
}