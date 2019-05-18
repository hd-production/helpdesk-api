using AutoMapper;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HdProduction.HelpDesk.Api.Controllers
{
    [Route("ticket-statuses"), ApiController, ApiVersion("0")]
    public class TicketStatusesController : TicketAttributeControllerBase<TicketStatus>
    {
        public TicketStatusesController(ITicketAttributeService<TicketStatus> service, IMapper mapper) 
            : base(service, mapper)
        {
        }
    }
}