using System.Collections.Generic;
using System.Threading.Tasks;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HdProduction.HelpDesk.Api.Controllers
{
    [Route("ticket-statuses"), ApiController, ApiVersion("0")]
    public class TicketStatusesController: ControllerBase
    {
        private readonly ITicketStatusService _ticketStatusService;

        public TicketStatusesController(ITicketStatusService ticketStatusService)
        {
            _ticketStatusService = ticketStatusService;
        }
        
        [HttpGet()]
        public async Task<List<TicketStatus>> Get()
        {
            return await _ticketStatusService.GetAllAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<TicketStatus> Get(long id)
        {
            return await _ticketStatusService.FindById(id);
        }
        
        [HttpPost()]
        public async Task<TicketStatus> Create(TicketStatus ticketStatus)
        {
            return await _ticketStatusService.CreateAsync(ticketStatus);
        }

        [HttpPut("{id}")]
        public async Task<TicketStatus> Update(long id, TicketStatus ticketStatus)
        {
            return await _ticketStatusService.UpdateAsync(id, ticketStatus);
        }
        
        [HttpDelete("{id}")]
        public async Task Delete(long id)
        {
            await _ticketStatusService.DeleteAsync(id);
        }
    }
}