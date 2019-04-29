using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HdProduction.HelpDesk.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public Task<User> FindAsync(long id, bool withTracking = true)
        {
            return _context.Users.FindAsync(id);
        }

        public void Add(User entity)
        {
            _context.Users.Add(entity);
        }

        public void Remove(User entity)
        {
            _context.Users.Remove(entity);
        }

        public Task SaveAsync()
        {
            return _context.SaveChangesAsync();
        }

        public Task<User> FindByEmailAsync(string email)
        {
            return _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}