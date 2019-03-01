using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
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

    public void Add(Ticket entity)
    {
      _context.Tickets.Add(entity);
    }

    public void Remove(Ticket entity)
    {
      _context.Tickets.Remove(entity);
    }

    public async Task SaveAsync()
    {
      await _context.SaveChangesAsync();
    }

    public async Task<List<Ticket>> GetAllAsync(bool trackEntities = true)
    {
      return trackEntities
        ? await _context.Tickets.ToListAsync()
        : await _context.Tickets.AsNoTracking().ToListAsync();
    }
  }
}