namespace HdProduction.HelpDesk.Domain.Entities
{
  public class TicketAttachment
  {
    public TicketAttachment(long ticketId, string attachmentKey)
    {
      TicketId = ticketId;
      AttachmentKey = attachmentKey;
    }

    public long TicketId { get; }
    public string AttachmentKey { get; }

    public Ticket Ticket { get; set; } // ef
  }
}