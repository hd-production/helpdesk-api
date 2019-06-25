using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HdProduction.HelpDesk.Infrastructure.Repositories
{
    public class TicketAttributeRepository<T> : RepositoryBase<T, int>, ITicketAttributeRepository<T>
        where T : TicketAttribute
    {
        public TicketAttributeRepository(ApplicationContext context) : base(context)
        {
        }

        public Task<List<T>> GetAllAsync(long projectId)
        {
            return Context.Set<T>().Where(ta => ta.ProjectId == projectId).ToListAsync();
        }

        public Task<T> FindByNameAsync(string name, long projectId)
        {
            return Context.Set<T>()
                .FirstOrDefaultAsync(s => s.Name == name && s.ProjectId == projectId);
        }

        public async Task<TicketAttribute> FindDefaultAsync()
        {
            return await Context.Set<T>().FirstOrDefaultAsync(s => s.Default);
        }
    }
}