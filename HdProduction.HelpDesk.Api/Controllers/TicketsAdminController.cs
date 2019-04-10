using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HdProduction.App.Common.Auth;
using HdProduction.HelpDesk.Api.Models.Tickets;
using HdProduction.HelpDesk.Domain.Contract;
using Microsoft.AspNetCore.Mvc;

namespace HdProduction.HelpDesk.Api.Controllers
{
  [Route("tickets/admin"), ApiController, ApiVersion("0")]
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
    public async Task<List<TicketAdminResponseModel>> Get()
    {
      return _mapper.Map<List<TicketAdminResponseModel>>(await _ticketsRepository.GetAllAsync());
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

    [HttpPut("{id}/comment")]
    public async Task<TicketAdminResponseModel> AddComment(long id, TicketRequestModel requestModel)
    {
      await _ticketService.UpdateAsync(id);
      return await Get(id);
    }
  }
}