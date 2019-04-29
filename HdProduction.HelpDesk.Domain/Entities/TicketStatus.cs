namespace HdProduction.HelpDesk.Domain.Entities
{
  public class TicketStatus: EntityBase<long>
  {
    public string Name { set; get; }
  }
}