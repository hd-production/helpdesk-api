using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Domain.Contract
{
  public interface IUserRepository : IRepository<User, long>
  {
    Task<User> FindByEmail(string email);
  }
}