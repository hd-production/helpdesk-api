using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using HdProduction.HelpDesk.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HdProduction.HelpDesk.Infrastructure.Repositories
{
  public class TicketsRepository : ITicketsRepository
  {
    private readonly ApplicationContext _context;

    public TicketsRepository(ApplicationContext context)
    {
      _context = context;
    }

    public Task<Ticket> FindAsync(long id, bool withTracking = true)
    {
      return withTracking
        ? _context.Tickets.FindAsync(id)
        : _context.Tickets.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Ticket> FindForAdminAsync(long id)
    {
      var entity = await _context.Tickets
        .Include(e => e.Attachments)
        .Include(e => e.Comments)
        .Include(e => e.Actions)
        .FirstOrDefaultAsync(e => e.Id == id);

      return entity;
    }

    public void Add(Ticket entity)
    {
      _context.Tickets.Add(entity);
    }

    public void Remove(Ticket entity)
    {
      _context.Tickets.Remove(entity);
    }

    public Task SaveAsync()
    {
      return _context.SaveChangesAsync();
    }

    public async Task<List<Ticket>> GetAllAsync(bool trackEntities = true)
    {
      return trackEntities
        ? await _context.Tickets.ToListAsync()
        : await _context.Tickets.AsNoTracking().ToListAsync();
    }

    public Task<List<TicketItemModel>> GetByUserAsync(long assigneeId)
    {
      return _context.Tickets
        .Where(t => t.AssigneeId == assigneeId)
        .Select(t => new TicketItemModel(t.Id, t.Issue))
        .ToListAsync();
    }
  }
}