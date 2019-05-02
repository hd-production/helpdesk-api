using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Domain.Contract
{
    public interface ITicketActionRepository : IRepository<TicketAction, long>
    {
    }
}