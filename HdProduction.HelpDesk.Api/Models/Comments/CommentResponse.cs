using System;

namespace HdProduction.HelpDesk.Api.Models.Comments
{
  public class CommentResponse : CommentRequest
  {
    public long TicketId { get; set;  }
    public long UserId { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}