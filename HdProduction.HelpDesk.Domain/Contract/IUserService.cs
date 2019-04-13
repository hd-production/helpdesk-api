using System.Threading.Tasks;

namespace HdProduction.HelpDesk.Domain.Contract
{
    public interface IUserService
    {
        Task CreateAsync(string email, string pwdHash);
    }
}