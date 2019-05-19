using System.Collections.Generic;

namespace HdProduction.HelpDesk.Domain.Entities
{
  public class Ticket : EntityBase<long>
  {
    public Ticket(string issue, string details, long? assigneeId, int? priorityId, int? statusId, int? categoryId)
    {
      Issue = issue;
      Details = details;
      AssigneeId = assigneeId;
      PriorityId = priorityId;
      StatusId = statusId;
      CategoryId = categoryId;
    }

    public string Issue { get; }
    public string Details { get; }
    public long? AssigneeId { get; }
    public int? PriorityId { get; }
    public int? StatusId { get; }
    public int? CategoryId { get; }
   
    public TicketPriority Priority { get; set; } // ef
    public TicketStatus Status { get; set; } // ef
    public TicketCategory Category { get; set; } // ef
    public ICollection<Comment> Comments { get; set; } // ef
    public ICollection<TicketAction> Actions { get; set; } // ef
    public ICollection<TicketAttachment> Attachments { get; set; } // ef
  }
}