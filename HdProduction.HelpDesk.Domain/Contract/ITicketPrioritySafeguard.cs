using System.Threading.Tasks;

namespace HdProduction.HelpDesk.Domain.Contract
{
    public interface ITicketPrioritySafeguard
    {
        Task EnsureNameAsync(string name);
    }
}