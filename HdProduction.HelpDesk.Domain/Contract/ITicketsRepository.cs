using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Entities;
using HdProduction.HelpDesk.Domain.Models;

namespace HdProduction.HelpDesk.Domain.Contract
{
  public interface ITicketsRepository : IRepository<Ticket, long>
  {
    Task<Ticket> FindForAdminAsync(long id);
    Task<List<Ticket>> GetAllAsync(bool withTracking = true);
    Task<List<TicketItemModel>> GetByUserAsync(long assigneeId);
    
  }
}