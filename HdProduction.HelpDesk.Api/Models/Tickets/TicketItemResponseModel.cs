namespace HdProduction.HelpDesk.Api.Models.Tickets
{
  public class TicketItemResponseModel
  {
    public long Id { get; set; }
    public string Details { get; set; }
    public string Issue { get; set; }
    public long? AssigneeId { get; set; }
  }
}