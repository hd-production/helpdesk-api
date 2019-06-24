using System.Collections.Generic;
using System.Linq;
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
        .Include(e => e.Status)
        .Include(e => e.Category)
        .Include(e => e.Priority)
        .FirstOrDefaultAsync(e => e.Id == id);

      return entity;
    }

    public async Task<List<Ticket>> GetAllAsync(long projectId, bool trackEntities = true)
    {
      var entities = Context.Tickets
        .Where  (e => e.ProjectId == projectId)
        .Include(e => e.Attachments)
        .Include(e => e.Comments)
        .Include(e => e.Actions)
        .Include(e => e.Status)
        .Include(e => e.Category)
        .Include(e => e.Priority)
        .OrderByDescending(e => e.Id);

      return trackEntities
        ? await entities.ToListAsync()
        : await entities.AsNoTracking().ToListAsync();
    }
  }
}