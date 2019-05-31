using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HdProduction.HelpDesk.Api.Models.TicketAttributes;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HdProduction.HelpDesk.Api.Controllers
{
    [Authorize]
    public abstract class TicketAttributeControllerBase<T> : ControllerBase
        where T : TicketAttribute
    {
        private readonly IMapper _mapper;
        private readonly ITicketAttributeService<T> _service;

        protected TicketAttributeControllerBase(ITicketAttributeService<T> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<TicketAttributeResponse>> Get()
        {
            var entities = await _service.GetAllAsync();
            return entities.Select(_mapper.Map<TicketAttributeResponse>);
        }

        [HttpGet("{id}")]
        public async Task<TicketAttributeResponse> Get(int id)
        {
            var entity = await _service.FindById(id);
            return _mapper.Map<TicketAttributeResponse>(entity);
        }

        [HttpPost]
        public async Task<TicketAttributeResponse> Create(TicketAttributeRequest ticketAttributeData)
        {
            var id = await _service.CreateAsync(ticketAttributeData.Name);
            return await Get(id);
        }

        [HttpPut("{id}")]
        public async Task<TicketAttributeResponse> Update(int id, TicketAttributeRequest ticketAttributeData)
        {
            await _service.UpdateAsync(id, ticketAttributeData.Name);
            return await Get(id);
        }

        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            return _service.DeleteAsync(id);
        }
    }
}