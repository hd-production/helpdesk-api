using System;

namespace HdProduction.HelpDesk.Domain.Entities
{
  public class TicketAction : EntityBase<long>
  {
    public TicketAction(long ticketId, long userId, ActionType type, DateTime time,
      long? oldAssigneeId = default, long? newAssigneeId = default, int? oldStatusId = default, int? newStatusId = default,
      long? commentId = default)
    {
      TicketId = ticketId;
      UserId = userId;
      Type = type;
      Time = time;
      OldAssigneeId = oldAssigneeId;
      NewAssigneeId = newAssigneeId;
      OldStatusId = oldStatusId;
      NewStatusId = newStatusId;
      CommentId = commentId;
    }

    public long TicketId { get; }
    public long UserId { get; }
    public ActionType Type { get; }
    public DateTime Time { get; }

    public long? OldAssigneeId { get; }
    public long? NewAssigneeId { get; }
    public int? OldStatusId { get; }
    public int? NewStatusId { get; }
    public long? CommentId { get; }

    public Ticket Ticket { get; set; } // ef
    public User User { get; set; } // ef
  }
}