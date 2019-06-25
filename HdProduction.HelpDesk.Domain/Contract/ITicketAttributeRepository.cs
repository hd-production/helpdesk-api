using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Domain.Contract
{
    public interface ITicketAttributeRepository<T> : IRepository<T, int> where T : TicketAttribute
    {
        Task<List<T>> GetAllAsync(long projectId);
        Task<T> FindByNameAsync(string name, long projectId);
        Task<TicketAttribute> FindDefaultAsync(long projectId);
    }
}