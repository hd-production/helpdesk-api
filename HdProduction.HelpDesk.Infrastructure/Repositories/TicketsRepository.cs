using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using HdProduction.HelpDesk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HdProduction.HelpDesk.Infrastructure.Repositories
{
  public class TicketsRepository : RepositoryBase<Ticket, long>, ITicketsRepository
  {
    public TicketsRepository(ApplicationContext context) : base(context)
    {
    }
    
    public async Task<Ticket> FindForAdminAsync(long id)
    {
      var entity = await Context.Tickets
        .Include(e => e.Attachments)
        .Include(e => e.Comments)
        .Include(e => e.Actions)
        .FirstOrDefaultAsync(e => e.Id == id);

      return entity;
    }
    
    public async Task<List<Ticket>> GetAllAsync(bool trackEntities = true)
    {
      return trackEntities
        ? await Context.Tickets.ToListAsync()
        : await Context.Tickets.AsNoTracking().ToListAsync();
    }

    public Task<List<TicketItemModel>> GetByUserAsync(long assigneeId)
    {
      return Context.Tickets
        .Where(t => t.AssigneeId == assigneeId)
        .Select(t => new TicketItemModel(t.Id, t.Issue))
        .ToListAsync();
    }
  }
}