using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Domain.Contract
{
  public interface ITicketsRepository : IRepository<Ticket, long>
  {
    Task<List<Ticket>> GetAllAsync(bool withTracking = true);
  }
}