using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HdProduction.HelpDesk.Api.Models.Tickets;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HdProduction.HelpDesk.Api.Controllers
{
  [Route("tickets"), ApiController, ApiVersion("0")]
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
    public async Task<List<TicketResponseModel>> Get()
    {
      return _mapper.Map<List<TicketResponseModel>>(await _ticketService.GetAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<TicketResponseModel> Get(long id)
    {
      return _mapper.Map<TicketResponseModel>(await _ticketService.FindAsync(id));
    }
    
    [HttpPost("")]
    public async Task<TicketResponseModel> Create(TicketRequestModel requestModel)
    {
      var id = await _ticketService.CreateAsync(new Ticket(requestModel.Issue, requestModel.Details, requestModel.IssuerEmail));
      return await Get(id); 
    }
    
    [HttpPut("{id}")]
    public async Task<TicketResponseModel> Update(long id, TicketRequestModel requestModel)
    {
      await _ticketService.UpdateAsync(id);
      return await Get(id);
    }

    [HttpPost("{id}/comment")]
    public async Task<TicketResponseModel> AddComment(long id, CommentRequestModel requestModel)
    {
      await _ticketService.AddCommentAsync(requestModel.TicketId, requestModel.Text,
        requestModel.UserId, requestModel.ReplyToCommentId);
      return await Get(id);
    }
  }
}