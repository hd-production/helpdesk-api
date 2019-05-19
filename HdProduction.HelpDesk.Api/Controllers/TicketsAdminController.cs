using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HdProduction.HelpDesk.Api.Models.Tickets;
using HdProduction.HelpDesk.Domain.Contract;
using Microsoft.AspNetCore.Mvc;

namespace HdProduction.HelpDesk.Api.Controllers
{
  [ApiController, ApiVersion("0")]
  [Route("tickets/admin")]
  public class TicketsAdminController : ControllerBase
  {
    private readonly IMapper _mapper;
    private readonly ITicketsRepository _ticketsRepository;
    private readonly ITicketService _ticketService;

    public TicketsAdminController(IMapper mapper, ITicketsRepository ticketsRepository, ITicketService ticketService)
    {
      _mapper = mapper;
      _ticketsRepository = ticketsRepository;
      _ticketService = ticketService;
    }

    [HttpGet("")]
    public async Task<List<TicketItemResponseModel>> Get()
    {
      return _mapper.Map<List<TicketItemResponseModel>>(await _ticketsRepository.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<TicketAdminResponseModel> Get(long id)
    {
      return _mapper.Map<TicketAdminResponseModel>(await _ticketsRepository.FindForAdminAsync(id));
    }

    [HttpPut("{id}")]
    public async Task<TicketAdminResponseModel> Update(long id, TicketRequestModel requestModel)
    {
      await _ticketService.UpdateAsync(id);
      return await Get(id);
    }

    [HttpPost("{id}/comment")]
    public async Task<TicketAdminResponseModel> AddComment(long id, CommentRequestModel requestModel)
    {
      await _ticketService.AddCommentAsync(requestModel.TicketId, requestModel.Text,
        requestModel.UserId, requestModel.ReplyToCommentId);
      return await Get(id);
    }
  }
}