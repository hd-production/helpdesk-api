using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HdProduction.HelpDesk.Infrastructure.Repositories
{
    public class TicketStatusRepository: ITicketStatusRepository
    {
        private readonly ApplicationContext _context;

        public TicketStatusRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Task<TicketStatus> FindAsync(long id, bool withTracking = true)
        {
            return withTracking
                ? _context.TicketStatuses.FindAsync(id)
                : _context.TicketStatuses.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
        }

        public void Add(TicketStatus entity)
        {
            _context.TicketStatuses.Add(entity);
        }

        public void Remove(TicketStatus entity)
        {
            _context.TicketStatuses.Remove(entity);
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<List<TicketStatus>> GetAllAsync()
        {
            return _context.TicketStatuses.ToListAsync();
        }
    }
}