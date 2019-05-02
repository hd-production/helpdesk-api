using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Domain.Contract
{
    public interface ITicketStatusRepository: IRepository<TicketStatus, int>
    {
        Task<List<TicketStatus>> GetAllAsync();
        Task<TicketStatus> FindByNameAsync(string name);
    }
}