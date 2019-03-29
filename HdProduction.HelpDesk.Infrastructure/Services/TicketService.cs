using System;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using HdProduction.HelpDesk.Domain.Exceptions;

namespace HdProduction.HelpDesk.Infrastructure.Services
{
  public class TicketService : ITicketService
  {
    private readonly ApplicationContext _dbContext;
    private readonly ITicketsRepository _ticketsRepository;

    public TicketService(ITicketsRepository ticketsRepository, ApplicationContext dbContext)
    {
      _ticketsRepository = ticketsRepository;
      _dbContext = dbContext;
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

    public async Task AddCommentAsync(Comment comment)
    {
      using (var transaction = await _dbContext.Database.BeginTransactionAsync())
      {
        _dbContext.Comments.Add(comment);
        await _dbContext.SaveChangesAsync();

        _dbContext.Actions.Add(new TicketAction(comment.TicketId, comment.UserId, ActionType.Comment, DateTime.UtcNow, commentId: comment.Id));
        await _dbContext.SaveChangesAsync();

        transaction.Commit();
      }
    }
  }
}