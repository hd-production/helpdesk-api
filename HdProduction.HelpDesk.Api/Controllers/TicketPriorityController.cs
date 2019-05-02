using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HdProduction.HelpDesk.Api.Models.TicketPriorities;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HdProduction.HelpDesk.Api.Controllers
{
    [Route("ticket-priorities"), ApiController, ApiVersion("0")]
    public class TicketPriorityController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITicketPriorityService _ticketPriorityService;

        public TicketPriorityController(ITicketPriorityService ticketPriorityService, IMapper mapper)
        {
            _mapper = mapper;
            _ticketPriorityService = ticketPriorityService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<TicketPriorityResponse>> Get()
        {
            var ticketPriorities = await _ticketPriorityService.GetAllAsync();
            return ticketPriorities.Select(_mapper.Map<TicketPriorityResponse>);
        }
        
        [HttpGet("{id}")]
        public async Task<TicketPriorityResponse> Get(int id)
        {
            var ticketPriority = await _ticketPriorityService.FindById(id);
            return _mapper.Map<TicketPriority, TicketPriorityResponse>(ticketPriority);
        }
        
        [HttpPost]
        public async Task<TicketPriorityResponse> Create(TicketPriorityRequest requestModel)
        {
            var id = await _ticketPriorityService.CreateAsync(requestModel.Name);
            return await Get(id);
        }

        [HttpPut("{id}")]
        public async Task<TicketPriorityResponse> Update(int id, TicketPriorityRequest requestModel)
        {
            await _ticketPriorityService.UpdateAsync(id, requestModel.Name);
            return await Get(id);
        }
        
        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            return _ticketPriorityService.DeleteAsync(id);
        }
    }
}