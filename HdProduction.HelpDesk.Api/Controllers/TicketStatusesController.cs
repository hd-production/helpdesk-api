using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HdProduction.HelpDesk.Api.Models.TicketStatuses;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HdProduction.HelpDesk.Api.Controllers
{
    [Route("ticket-statuses"), ApiController, ApiVersion("0")]
    public class TicketStatusesController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITicketStatusService _ticketStatusService;

        public TicketStatusesController(ITicketStatusService ticketStatusService, IMapper mapper)
        {
            _mapper = mapper;
            _ticketStatusService = ticketStatusService;
        }
        
        [HttpGet()]
        public async Task<List<TicketStatusResponse>> Get()
        {
            var ticketStatuses = await _ticketStatusService.GetAllAsync();
            return (from x in ticketStatuses
                select _mapper.Map<TicketStatus, TicketStatusResponse>(x)).ToList();
        }
        
        [HttpGet("{id}")]
        public async Task<TicketStatusResponse> Get(long id)
        {
            var ticketStatus = await _ticketStatusService.FindById(id);
            return _mapper.Map<TicketStatus, TicketStatusResponse>(ticketStatus);
        }
        
        [HttpPost()]
        public async Task<TicketStatusResponse> Create(TicketStatusRequest ticketStatusData)
        {
            var ticketStatus = _mapper.Map<TicketStatusRequest, TicketStatus>(ticketStatusData);
            ticketStatus = await _ticketStatusService.CreateAsync(ticketStatus);
            return _mapper.Map<TicketStatus, TicketStatusResponse>(ticketStatus);
        }

        [HttpPut("{id}")]
        public async Task<TicketStatusResponse> Update(long id, TicketStatusRequest ticketStatusData)
        {
            var ticketStatus = _mapper.Map<TicketStatusRequest, TicketStatus>(ticketStatusData);
            ticketStatus = await _ticketStatusService.UpdateAsync(id, ticketStatus);
            return _mapper.Map<TicketStatus, TicketStatusResponse>(ticketStatus);
        }
        
        [HttpDelete("{id}")]
        public Task Delete(long id)
        {
            return _ticketStatusService.DeleteAsync(id);
        }
    }
}