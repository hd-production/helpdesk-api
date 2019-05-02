using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HdProduction.HelpDesk.Infrastructure.Repositories
{
    public class UserRepository : RepositoryBase<User, long>, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public Task<User> FindByEmailAsync(string email)
        {
            return Context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}