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
        
        [HttpGet]
        public async Task<IEnumerable<TicketStatusResponse>> Get()
        {
            var ticketStatuses = await _ticketStatusService.GetAllAsync();
            return ticketStatuses.Select(_mapper.Map<TicketStatusResponse>);
        }
        
        [HttpGet("{id}")]
        public async Task<TicketStatusResponse> Get(int id)
        {
            var ticketStatus = await _ticketStatusService.FindById(id);
            return _mapper.Map<TicketStatus, TicketStatusResponse>(ticketStatus);
        }
        
        [HttpPost]
        public async Task<TicketStatusResponse> Create(TicketStatusRequest ticketStatusData)
        {
            var id = await _ticketStatusService.CreateAsync(ticketStatusData.Name);
            return await Get(id);
        }

        [HttpPut("{id}")]
        public async Task<TicketStatusResponse> Update(int id, TicketStatusRequest ticketStatusData)
        {
            await _ticketStatusService.UpdateAsync(id, ticketStatusData.Name);
            return await Get(id);
        }
        
        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            return _ticketStatusService.DeleteAsync(id);
        }
    }
}