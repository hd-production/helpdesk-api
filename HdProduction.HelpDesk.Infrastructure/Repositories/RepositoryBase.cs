using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HdProduction.HelpDesk.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T, TKey> : IRepository<T, TKey> 
        where T : class, IEntity<TKey>
        where TKey : struct
    {
        protected readonly ApplicationContext Context;

        protected RepositoryBase(ApplicationContext context)
        {
            Context = context;
        }

        public Task<T> FindAsync(TKey id, bool withTracking = true)
        {
            return withTracking
                ? Context.Set<T>().FindAsync(id)
                : Context.Set<T>().AsNoTracking().FirstOrDefaultAsync(e => e.Key.Equals(id));
        }

        public void Add(T entity)
        {
            Context.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public Task SaveAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}