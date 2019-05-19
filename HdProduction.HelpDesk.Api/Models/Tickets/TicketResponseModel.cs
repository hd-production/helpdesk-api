using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Api.Models.Tickets
{
    public class TicketResponseModel : TicketRequestModel
    {
        public long Id { get; set; }
        public TicketAttribute TicketStatus {get;set;}
        public TicketAttribute Priority { get; set; }
        public TicketAttribute Category { get; set; }
    }
}