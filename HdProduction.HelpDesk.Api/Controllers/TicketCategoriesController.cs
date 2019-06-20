using AutoMapper;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace HdProduction.HelpDesk.Api.Controllers
{
    [Route("ticket-categories"), ApiController, ApiVersion("0")]
    public class TicketCategoriesController : TicketAttributeControllerBase<TicketCategory>
    {
        public TicketCategoriesController(ITicketAttributeService<TicketCategory> service, IMapper mapper)
            : base(service, mapper)
        {
        }
    }
}