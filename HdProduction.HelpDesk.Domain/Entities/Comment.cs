namespace HdProduction.HelpDesk.Domain.Entities
{
  public class Comment : EntityBase<long>
  {
    public Comment(long ticketId, string text, long userId)
    {
      TicketId = ticketId;
      Text = text;
      UserId = userId;
    }

    public long TicketId { get; }
    public string Text { get; }
    public long UserId { get; }
    
    public Ticket Ticket { get; set; } // ef
    public User User { get; set; } // ef
  }
}