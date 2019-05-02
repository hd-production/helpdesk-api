using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Domain.Contract
{
    public interface ITicketPriorityRepository: IRepository<TicketPriority, int>
    {
        Task<List<TicketPriority>> GetAllAsync();
        Task<TicketPriority> FindByNameAsync(string name);
    }
}