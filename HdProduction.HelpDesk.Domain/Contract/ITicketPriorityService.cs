using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Domain.Contract
{
    public interface ITicketPriorityService
    {
        Task<TicketPriority> FindById(int id);
        Task<List<TicketPriority>> GetAllAsync();
        Task<int> CreateAsync(string name);
        Task UpdateAsync(int id, string name); 
        Task DeleteAsync(int id);
    }
}