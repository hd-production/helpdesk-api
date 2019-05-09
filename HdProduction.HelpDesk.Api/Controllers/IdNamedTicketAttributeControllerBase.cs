using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HdProduction.HelpDesk.Api.Models.IdNamedTicketAttributes;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HdProduction.HelpDesk.Api.Controllers
{
    public abstract class IdNamedTicketAttributeControllerBase<T> : ControllerBase
        where T : IdNamedTicketAttribute
    {
        private readonly IMapper _mapper;
        private readonly IIdNamedTicketAttributeService<T> _service;

        protected IdNamedTicketAttributeControllerBase(IIdNamedTicketAttributeService<T> service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
        }
        
        [HttpGet]
        public async Task<IEnumerable<IdNamedTicketAttributeResponse>> Get()
        {
            var entities = await _service.GetAllAsync();
            return entities.Select(_mapper.Map<IdNamedTicketAttributeResponse>);
        }
        
        [HttpGet("{id}")]
        public async Task<IdNamedTicketAttributeResponse> Get(int id)
        {
            var entity = await _service.FindById(id);
            return _mapper.Map<IdNamedTicketAttributeResponse>(entity);
        }
        
        [HttpPost]
        public async Task<IdNamedTicketAttributeResponse> Create(IdNamedTicketAttributeRequest idNamedTicketAttributeData)
        {
            var id = await _service.CreateAsync(idNamedTicketAttributeData.Name);
            return await Get(id);
        }

        [HttpPut("{id}")]
        public async Task<IdNamedTicketAttributeResponse> Update(int id, IdNamedTicketAttributeRequest idNamedTicketAttributeData)
        {
            await _service.UpdateAsync(id, idNamedTicketAttributeData.Name);
            return await Get(id);
        }
        
        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            return _service.DeleteAsync(id);
        }
    }
}