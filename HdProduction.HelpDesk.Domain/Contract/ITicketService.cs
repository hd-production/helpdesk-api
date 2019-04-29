using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Domain.Contract
{
  public interface ITicketService
  {
    Task<long> CreateAsync(Ticket ticket);
    Task UpdateAsync(long id);

    Task AddCommentAsync(long ticketId, string text, long userId, long? replyToId);
  }
}