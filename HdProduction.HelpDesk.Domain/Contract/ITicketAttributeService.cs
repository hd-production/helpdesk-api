using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Domain.Contract
{
    public interface ITicketAttributeService<T>
    {
        Task<T> FindById(int id);
        Task<List<T>> GetAllAsync(long projectId);
        Task<int> CreateAsync(string name, long projectId);
        Task UpdateAsync(int id, string name);
        Task DeleteAsync(int id);
    }
}