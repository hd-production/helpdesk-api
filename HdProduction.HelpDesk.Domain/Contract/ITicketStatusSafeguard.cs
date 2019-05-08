using System.Threading.Tasks;

namespace HdProduction.HelpDesk.Domain.Contract
{
    public interface ITicketStatusSafeguard
    {
        Task EnsureNameAsync(string name);
    }
}