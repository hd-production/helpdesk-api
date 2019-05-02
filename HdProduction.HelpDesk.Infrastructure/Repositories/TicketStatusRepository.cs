using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HdProduction.HelpDesk.Infrastructure.Repositories
{
    public class TicketStatusRepository: RepositoryBase<TicketStatus, int>, ITicketStatusRepository
    {
        public TicketStatusRepository(ApplicationContext context) : base(context)
        {
        }

        public Task<List<TicketStatus>> GetAllAsync()
        {
            return Context.TicketStatuses.ToListAsync();
        }

        public Task<TicketStatus> FindByNameAsync(string name)
        {
            return Context.TicketStatuses.FirstOrDefaultAsync(s => s.Name == name);
        }
    }
}