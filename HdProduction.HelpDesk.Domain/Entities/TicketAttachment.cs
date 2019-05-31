using System;

namespace HdProduction.HelpDesk.Domain.Entities
{
  public class TicketAttachment : IEntity<Guid>
  {
    public TicketAttachment(long ticketId, Guid key, string url)
    {
      TicketId = ticketId;
      Key = key;
      Url = url;
    }

    public long TicketId { get; }
    public Guid Key { get; }
    public string Url { get; }

    public Ticket Ticket { get; set; } // ef

    public const int MaxUrlLength = 256;
  }
}