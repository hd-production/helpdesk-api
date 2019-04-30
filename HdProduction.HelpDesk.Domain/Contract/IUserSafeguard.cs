using System.Threading.Tasks;

namespace HdProduction.HelpDesk.Domain.Contract
{
    public interface IUserSafeguard
    {
        Task EnsureEmailAsync(string email);
    }
}