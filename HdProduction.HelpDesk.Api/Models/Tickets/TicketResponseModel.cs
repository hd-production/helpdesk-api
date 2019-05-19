using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Api.Models.Tickets
{
    public class TicketResponseModel : TicketRequestModel
    {
        public long Id { get; set; }
        public TicketStatus TicketStatus {get;set;}
        public TicketPriority Priority { get; set; }
        public TicketCategory Category { get; set; }
    }
}