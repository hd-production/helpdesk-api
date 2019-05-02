using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HdProduction.HelpDesk.Infrastructure.Repositories
{
    public class TicketPriorityRepository: RepositoryBase<TicketPriority, int>, ITicketPriorityRepository
    {
        public TicketPriorityRepository(ApplicationContext context) : base(context)
        {
        }

        public Task<List<TicketPriority>> GetAllAsync()
        {
            return Context.TicketPriorities.ToListAsync();
        }

        public Task<TicketPriority> FindByNameAsync(string name)
        {
            return Context.TicketPriorities.FirstOrDefaultAsync(p => p.Name == name);
        }
    }
}