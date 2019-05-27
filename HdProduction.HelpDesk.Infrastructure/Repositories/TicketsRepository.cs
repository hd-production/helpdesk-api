using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HdProduction.HelpDesk.Infrastructure.Repositories
{
  public class TicketsRepository : RepositoryBase<Ticket, long>, ITicketsRepository
  {
    public TicketsRepository(ApplicationContext context) : base(context)
    {
    }
    
    public async Task<Ticket> FindAsync(long id)
    {
      var entity = await Context.Tickets
        .Include(e => e.Attachments)
        .Include(e => e.Comments)
        .Include(e => e.Actions)
        .Include(e => e.TicketStatus)
        .Include(e => e.Category)
        .Include(e => e.Priority)
        .FirstOrDefaultAsync(e => e.Id == id);

      return entity;
    }
    
    public async Task<List<Ticket>> GetAllAsync(bool trackEntities = true)
    {
      var entities = Context.Tickets
        .Include(e => e.Attachments)
        .Include(e => e.Comments)
        .Include(e => e.Actions)
        .Include(e => e.Category)
        .Include(e => e.Priority)
        .Include(e => e.TicketStatus);
      
      return trackEntities
        ? await entities.ToListAsync()
        : await entities.AsNoTracking().ToListAsync();
    }
  }
}