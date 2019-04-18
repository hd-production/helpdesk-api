using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Domain.Contract
{
    public interface ITicketStatusRepository: IRepository<TicketStatus, long>
    {
        Task<List<TicketStatus>> GetAllAsync();
    }
}