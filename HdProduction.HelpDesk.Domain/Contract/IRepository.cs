using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Domain.Contract
{
  public interface IRepository<T, in TKey> where T : IEntity<TKey> where TKey : struct
  {
    Task<T> FindAsync(TKey id, bool withTracking = true);
    void Add(T entity);
    void Remove(T entity);
    Task SaveAsync();
  }
}