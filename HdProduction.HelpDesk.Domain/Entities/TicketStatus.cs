using System.Collections.Generic;

namespace HdProduction.HelpDesk.Domain.Entities
{
  public class TicketStatus: EntityBase<int>
  {
    public TicketStatus(string name)
    {
      Name = name;
    }

    public string Name { set; get; }
    
    public ICollection<Ticket> Tickets { get; set; } // ef

    public const int MaxNameLength = 32;
  }
}