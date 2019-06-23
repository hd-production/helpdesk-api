using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HdProduction.HelpDesk.Api.Extensions;
using HdProduction.HelpDesk.Api.Models.Comments;
using HdProduction.HelpDesk.Api.Models.Tickets;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Exceptions;
using HdProduction.HelpDesk.Domain.Metadata;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HdProduction.HelpDesk.Api.Controllers
{
  [ApiController, ApiVersion("0")]
  [Route("tickets")]
  [Authorize(Roles = Permissions.SupportAgentRole)]
  public class TicketsController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly ITicketService _ticketService;

    public TicketsController(IMapper mapper, ITicketService ticketService)
    {
      _mapper = mapper;
      _ticketService = ticketService;
    }

    [HttpGet("")]
    public async Task<IEnumerable<TicketResponse>> Get()
    {
      var tickets = await _ticketService.GetAllAsync(User.GetProjectId());
      return tickets.Select(_mapper.Map<TicketResponse>);
    }

    [HttpGet("{id}")]
    public async Task<TicketResponse> Get(long id)
    {
      return _mapper.Map<TicketResponse>(await _ticketService.FindAsync(id));
    }

    [HttpPost(""), AllowAnonymous]
    public async Task<TicketResponse> Create(TicketRequest request)
    {
      var id = await _ticketService.CreateAsync(request.Issue, request.Details, request.IssuerEmail);
      return await Get(id);
    }

    [HttpPut("{id}")]
    public async Task<TicketResponse> Update(long id, TicketRequest request)
    {
      await _ticketService.UpdateAsync(id, request.Issue, request.Details, request.IssuerEmail, request.AssigneeId,
        request.PriorityId, request.StatusId, request.CategoryId);
      return await Get(id);
    }

    [HttpDelete("{id}")]
    public Task Delete(long id)
    {
      return _ticketService.DeleteAsync(id);
    }

    [HttpPost("{id}/comment")]
    public async Task<TicketResponse> AddComment(long id, CommentRequest request)
    {
      await _ticketService.AddCommentAsync(id, request.Text, User.GetId(), request.ReplyToCommentId);
      return await Get(id);
    }

    [HttpPut("{id}/comment/{commentId}")]
    public async Task<TicketResponse> EditComment(long id, long commentId, CommentRequest request)
    {
      await _ticketService.EditCommentAsync(commentId, request.Text, User.GetId());
      return await Get(id);
    }

    [HttpPost("{id}/attachment")]
    public async Task<TicketResponse> AddAttachment(long id)
    {
      var file = Request.Form.Files?.FirstOrDefault();
      if (file is null)
      {
        throw new BusinessLogicException("File is not attached");
      }
      await _ticketService.AddAttachmentAsync(id, User.GetId(), file.FileName, file.OpenReadStream());
      return await Get(id);
    }

    [HttpDelete("{id}/attachment/{key:guid}")]
    public Task Delete(long id, Guid key)
    {
      return _ticketService.RemoveAttachmentAsync(key, User.GetId());
    }
  }
}