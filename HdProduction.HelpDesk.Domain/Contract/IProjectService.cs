using System.Threading.Tasks;

namespace HdProduction.HelpDesk.Domain.Contract
{
    public interface IProjectService
    {
        Task FindAsync(long id);
        Task<long> CreateAsync(long dashboardId, string name);
    }
}