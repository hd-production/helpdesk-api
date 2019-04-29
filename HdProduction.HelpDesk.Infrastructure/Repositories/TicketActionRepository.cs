using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Infrastructure.Repositories
{
    public class TicketActionRepository : RepositoryBase<TicketAction, long>, ITicketActionRepository
    {
        public TicketActionRepository(ApplicationContext context) : base(context)
        {
        }
    }
}