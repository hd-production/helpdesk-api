using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Domain.Contract
{
    public interface IIdNamedTicketAttributeRepository<T> : IRepository<T, int> where T : IdNamedTicketAttribute
    {
        Task<List<T>> GetAllAsync();
        Task<T> FindByNameAsync(string name);
    }
}