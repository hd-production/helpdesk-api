using System;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Api.Models.Actions
{
  public class TicketActionResponse
  {
    public long TicketId { get; set; }
    public long UserId { get; set; }
    public ActionType Type { get; set; }
    public DateTime Time { get; set; }

    public long? OldAssigneeId { get; set; }
    public long? NewAssigneeId { get; set; }
    public int? OldStatusId { get; set; }
    public int? NewStatusId { get; set; }
    public long? CommentId { get; set; }
    public Guid? AttachmentKey { get; set; }
  }
}