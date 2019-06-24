using System;
using System.Collections.Generic;
using System.IO;
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
    private readonly IAttachmentRepository _attachmentRepository;
    private readonly IAttachmentUploader _attachmentUploader;
    private readonly ITicketAttributeRepository<TicketPriority> _priorityRepository;
    private readonly ITicketAttributeRepository<TicketStatus> _statusRepository;
    private readonly ITicketAttributeRepository<TicketCategory> _categoryRepository;

    public TicketService(ITicketsRepository ticketsRepository,
      ICommentRepository commentRepository,
      ITicketActionRepository ticketActionRepository,
      IAttachmentRepository attachmentRepository,
      IAttachmentUploader attachmentUploader,
      ITicketAttributeRepository<TicketPriority> priorityRepository,
      ITicketAttributeRepository<TicketStatus> statusRepository,
      ITicketAttributeRepository<TicketCategory> categoryRepository)
    {
      _ticketsRepository = ticketsRepository;
      _commentRepository = commentRepository;
      _ticketActionRepository = ticketActionRepository;
      _attachmentRepository = attachmentRepository;
      _attachmentUploader = attachmentUploader;
      _priorityRepository = priorityRepository;
      _statusRepository = statusRepository;
      _categoryRepository = categoryRepository;
    }

    public Task<Ticket> FindAsync(long id)
    {
      return _ticketsRepository.FindAsync(id);
    }

    public Task<List<Ticket>> GetAllAsync(long projectId)
    {
      return _ticketsRepository.GetAllAsync(projectId);
    }

    public async Task<long> CreateAsync(string issue, string details, string issuerEmail, long projectId,
      long? assigneeId = null, int? priorityId = null, int? statusId = null, int? categoryId = null)
    {
      var ticket = new Ticket(issue, details, issuerEmail, projectId, assigneeId,
        priorityId ?? (await _priorityRepository.FindDefaultAsync())?.Id,
        statusId ?? (await _statusRepository.FindDefaultAsync())?.Id,
        categoryId ?? (await _categoryRepository.FindDefaultAsync())?.Id
      );
      _ticketsRepository.Add(ticket);
      await _ticketsRepository.SaveAsync();
      return ticket.Id;
    }

    public async Task UpdateAsync(long id,string issue, string details, string issuerEmail,
      long? assigneeId, int? priorityId, int? statusId, int? categoryId)
    {
      var ticket = await _ticketsRepository.FindAsync(id) ?? throw ExceptionsHelper.EntityNotFound(nameof(Ticket));
      ticket.Update(issue, details, issuerEmail, assigneeId, priorityId, statusId, categoryId);
      await _ticketsRepository.SaveAsync();
    }

    public async Task DeleteAsync(long id)
    {
      var ticket = await _ticketsRepository.FindAsync(id) ?? throw ExceptionsHelper.EntityNotFound(nameof(Ticket));
      _ticketsRepository.Remove(ticket);
      await _ticketsRepository.SaveAsync();
    }

    public Task AddCommentAsync(long ticketId, string text, long userId, long? replyToCommentId)
    {
      var comment = new Comment(ticketId, text, userId, replyToCommentId, DateTime.UtcNow);
      _commentRepository.Add(comment);
      _ticketActionRepository.Add(new TicketAction(ticketId, userId, ActionType.AddedComment, DateTime.UtcNow, commentId: comment.Id));
      return _commentRepository.SaveAsync();
    }

    public async Task EditCommentAsync(long commentId, string text, long userId)
    {
      var comment = await _commentRepository.FindAsync(commentId) ?? throw ExceptionsHelper.EntityNotFound(nameof(Comment));
      if (userId != comment.UserId)
      {
        throw ExceptionsHelper.UserDontHaveRights();
      }

      comment.Text = text;

      _ticketActionRepository.Add(new TicketAction(comment.TicketId, userId, ActionType.EditedComment, DateTime.UtcNow, commentId: comment.Id));
      await _commentRepository.SaveAsync();
    }

    public async Task AddAttachmentAsync(long ticketId, long userId, string fileName, Stream file)
    {
      var key = Guid.NewGuid();
      var extensionIdx = fileName.LastIndexOf('.');
      var safeFileName = fileName.Insert(extensionIdx - 1, key.ToString("N"));
      var url = await _attachmentUploader.UploadAsync(safeFileName, file);

      var attachment = new TicketAttachment(ticketId, key, url);
      _attachmentRepository.Add(attachment);
      _ticketActionRepository.Add(new TicketAction(ticketId, userId, ActionType.AddedAttachment, DateTime.UtcNow, attachmentKey: key));

      await _attachmentRepository.SaveAsync();
    }

    public async Task RemoveAttachmentAsync(Guid key, long userId)
    {
      var attachment = await _attachmentRepository.FindAsync(key) ?? throw ExceptionsHelper.EntityNotFound(nameof(TicketAttachment));
      _attachmentRepository.Remove(attachment);
      _ticketActionRepository.Add(new TicketAction(attachment.TicketId, userId, ActionType.RemovedAttachment, DateTime.UtcNow, attachmentKey: key));

      await _attachmentRepository.SaveAsync();
    }
  }
}