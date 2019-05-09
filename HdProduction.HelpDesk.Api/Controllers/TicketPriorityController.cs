using AutoMapper;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HdProduction.HelpDesk.Api.Controllers
{
    [Route("ticket-priorities"), ApiController, ApiVersion("0")]
    public class TicketPriorityController: IdNamedTicketAttributeControllerBase<TicketPriority>
    {
        public TicketPriorityController(IIdNamedTicketAttributeService<TicketPriority> service, IMapper mapper) 
            : base(service, mapper)
        {
        }
    }
}