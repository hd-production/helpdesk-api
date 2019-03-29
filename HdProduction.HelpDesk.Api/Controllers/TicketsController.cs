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
    private readonly ITicketsRepository _ticketsRepository;
    private readonly ITicketService _ticketService;

    public TicketsController(IMapper mapper, ITicketsRepository ticketsRepository, ITicketService ticketService)
    {
      _mapper = mapper;
      _ticketsRepository = ticketsRepository;
      _ticketService = ticketService;
    }

    [HttpGet("{id}")]
    public async Task<TicketAdminResponseModel> Get(long id)
    {
      return _mapper.Map<TicketAdminResponseModel>(await _ticketsRepository.FindAsync(id));
    }

    [HttpPost("")]
    public async Task<TicketAdminResponseModel> Create(TicketRequestModel requestModel)
    {
      var id = await _ticketService.CreateAsync(_mapper.Map<Ticket>(requestModel));
      return await Get(id);
    }
  }
}