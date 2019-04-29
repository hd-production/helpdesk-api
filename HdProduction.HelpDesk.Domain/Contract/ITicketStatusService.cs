using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Domain.Contract
{
    public interface ITicketStatusService
    {
        Task<TicketStatus> FindById(long id);
        Task<List<TicketStatus>> GetAllAsync();
        Task<TicketStatus> CreateAsync(TicketStatus ticketStatus);
        Task<TicketStatus> UpdateAsync(long id, TicketStatus ticketStatus);
        Task DeleteAsync(long id);
    }
}