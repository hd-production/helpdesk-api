using System;
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

    public async Task<long> CreateAsync(Ticket ticket)
    {
      _ticketsRepository.Add(ticket);
      await _ticketsRepository.SaveAsync();
      return ticket.Id;
    }

    public async Task UpdateAsync(long id)
    {
      var entity = await _ticketsRepository.FindAsync(id) ?? throw new EntityNotFoundException("Ticket not found");
      
    }

    public Task AddCommentAsync(long ticketId, string text, long userId, long? replyToId)
    {
      var comment = new Comment(ticketId, text, userId, replyToId);
        _commentRepository.Add(comment);
        _ticketActionRepository.Add(new TicketAction
          (comment.TicketId, comment.UserId, ActionType.Comment, DateTime.UtcNow, commentId: comment.Id));
        return _commentRepository.SaveAsync();
    }
  }
}