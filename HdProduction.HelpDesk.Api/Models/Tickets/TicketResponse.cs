using HdProduction.HelpDesk.Api.Models.Actions;
using HdProduction.HelpDesk.Api.Models.Comments;
using HdProduction.HelpDesk.Api.Models.TicketAttributes;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Api.Models.Tickets
{
    public class TicketResponse : TicketRequest
    {
        public long Id { get; set; } 
        public TicketAttributeResponse Status {get;set;}
        public TicketAttributeResponse Priority { get; set; }
        public TicketAttributeResponse Category { get; set; }
        public TicketAttachmentResponse[] Attachments { get; set; }
        public CommentResponse[] Comments { get; set; }
        public TicketActionResponse[] Actions { get; set; }
    }
}