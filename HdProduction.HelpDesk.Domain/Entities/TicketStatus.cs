namespace HdProduction.HelpDesk.Domain.Entities
{
  public class TicketStatus: EntityBase<int>
  {
    public TicketStatus(string name)
    {
      Name = name;
    }

    public string Name { set; get; }
  }
}