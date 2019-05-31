using System;
using System.Collections.Generic;

namespace HdProduction.HelpDesk.Domain.Entities
{
  public class Comment : EntityBase<long>
  {
    public Comment(long ticketId, string text, long userId, 
      long? replyToCommentId, DateTime createdAt)
    {
      TicketId = ticketId;
      Text = text;
      UserId = userId;
      ReplyToCommentId = replyToCommentId;
      CreatedAt = createdAt;
    }

    public long TicketId { get; }
    public string Text { get; set; }
    public long UserId { get; }
    public long? ReplyToCommentId { get; }
    public DateTime CreatedAt { get; }

    public Ticket Ticket { get; set; } // ef
    public User User { get; set; } // ef

    public Comment Parent { get; set; } // ef
    public ICollection<Comment> Replies { get; set; } // ef
  }
}