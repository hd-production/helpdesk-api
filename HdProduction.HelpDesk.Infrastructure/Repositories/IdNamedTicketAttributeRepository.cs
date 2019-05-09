using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HdProduction.HelpDesk.Infrastructure.Repositories
{
    public class IdNamedTicketAttributeRepository<T> : RepositoryBase<T, int>, IIdNamedTicketAttributeRepository<T>
        where T : IdNamedTicketAttribute
    {
        public IdNamedTicketAttributeRepository(ApplicationContext context) : base(context)
        {
        }

        public Task<List<T>> GetAllAsync()
        {
            return Context.Set<T>().ToListAsync();
        }

        public Task<T> FindByNameAsync(string name)
        {
            return Context.Set<T>().FirstOrDefaultAsync(s => s.Name == name);
        }
    }
}