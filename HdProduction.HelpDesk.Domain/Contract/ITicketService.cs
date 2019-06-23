using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Domain.Contract
{
  public interface ITicketService
  {
    Task<Ticket> FindAsync(long id);
    Task<List<Ticket>> GetAllAsync(long projectId);
    Task<long> CreateAsync(string issue, string details, string issuerEmail,
      long? assigneeId = null, int? priorityId = null, int? statusId = null, int? categoryId = null);
    Task UpdateAsync(long id,string issue, string details, string issuerEmail,
      long? assigneeId, int? priorityId, int? statusId, int? categoryId);
    Task DeleteAsync(long id);

    Task AddCommentAsync(long ticketId, string text, long userId, long? replyToCommentId);
    Task EditCommentAsync(long commentId, string text, long userId);
    Task AddAttachmentAsync(long ticketId, long userId, string fileName, Stream file);
    Task RemoveAttachmentAsync(Guid key, long userId);
  }
}