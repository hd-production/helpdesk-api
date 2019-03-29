namespace HdProduction.HelpDesk.Domain.Models
{
  public class TicketItemModel
  {
    public TicketItemModel(long id, string issue)
    {
      Id = id;
      Issue = issue;
    }

    public long Id { get; }
    public string Issue { get; }
  }
}