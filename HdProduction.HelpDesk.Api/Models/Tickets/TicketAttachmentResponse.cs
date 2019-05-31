using System;

namespace HdProduction.HelpDesk.Api.Models.Tickets
{
  public class TicketAttachmentResponse
  {
    public Guid Key { get; set; }
    public string Url { get; set; }
  }
}