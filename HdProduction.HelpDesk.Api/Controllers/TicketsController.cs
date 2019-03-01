using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HdProduction.HelpDesk.Api.Models;
using HdProduction.HelpDesk.Domain.Contract;
using Microsoft.AspNetCore.Mvc;

namespace HdProduction.HelpDesk.Api.Controllers
{
  [Route("tickets")]
  public class TicketsController
  {
    private readonly IMapper _mapper;
    private readonly ITicketsRepository _ticketsRepository;

    public TicketsController(IMapper mapper, ITicketsRepository ticketsRepository)
    {
      _mapper = mapper;
      _ticketsRepository = ticketsRepository;
    }

    [HttpGet("")]
    public async Task<List<TicketResponseModel>> Get()
    {
      return _mapper.Map<List<TicketResponseModel>>(await _ticketsRepository.GetAllAsync());
    }
  }
}