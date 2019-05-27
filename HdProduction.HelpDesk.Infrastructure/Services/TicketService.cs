using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using HdProduction.HelpDesk.Domain.Exceptions;

namespace HdProduction.HelpDesk.Infrastructure.Services
{
  public class TicketService : ITicketService
  {
    private readonly ICommentRepository _commentRepository;
    private readonly ITicketsRepository _ticketsRepository;
    private readonly ITicketActionRepository _ticketActionRepository;

    public TicketService(ITicketsRepository ticketsRepository,
      ICommentRepository commentRepository, 
      ITicketActionRepository ticketActionRepository)
    {
      _ticketsRepository = ticketsRepository;
      _commentRepository = commentRepository;
      _ticketActionRepository = ticketActionRepository;
    }

    public Task<Ticket> FindAsync(long id)
    {
      return _ticketsRepository.FindAsync(id);
    }

    public Task<List<Ticket>> GetAllAsync()
    {
      return _ticketsRepository.GetAllAsync();
    }

    public async Task<long> CreateAsync(string issue, string details, string issuerEmail, long? assigneeId = null, int? priorityId = null, int? statusId = null, int? categoryId = null)
    {
      var ticket = new Ticket(issue, details, issuerEmail, assigneeId, priorityId, statusId, categoryId);
      _ticketsRepository.Add(ticket);
      await _ticketsRepository.SaveAsync();
      return ticket.Id;
    }

    public async Task UpdateAsync(long id)
    {
      throw new NotImplementedException();
    }

    public Task AddCommentAsync(long ticketId, string text, long userId, long? replyToCommentId)
    {
      var comment = new Comment(ticketId, text, userId, replyToCommentId, DateTime.UtcNow);
        _commentRepository.Add(comment);
        _ticketActionRepository.Add(new TicketAction
          (comment.TicketId, comment.UserId, ActionType.Comment, DateTime.UtcNow, commentId: comment.Id));
        return _commentRepository.SaveAsync();
    }
  }
}