namespace HdProduction.HelpDesk.Api.Models.Tickets
{
  public class TicketRequest
  {
    public string Details { get; set; }
    public string Issue { get; set; }
    public string IssuerEmail { get; set; }
    public long? AssigneeId { get; set; }
    public int? PriorityId { get; set; }
    public int? StatusId { get; set; }
    public int? CategoryId { get; set; }
  }
}