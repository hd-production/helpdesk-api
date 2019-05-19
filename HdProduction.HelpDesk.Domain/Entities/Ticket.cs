using System.Collections.Generic;

namespace HdProduction.HelpDesk.Domain.Entities
{
  public class Ticket : EntityBase<long>
  {
    public Ticket(string issue, string details, string issuerEmail, long? assigneeId = null, int? priorityId = null, int? statusId = null, int? categoryId = null)
    {
      Issue = issue;
      Details = details;
      AssigneeId = assigneeId;
      IssuerEmail = issuerEmail;
      PriorityId = priorityId;
      StatusId = statusId;
      CategoryId = categoryId;
    }

    public string Issue { get; }
    public string Details { get; }
    public string IssuerEmail { get; }
    public long? AssigneeId { get; }
    public long? TicketStatusId { get; }
    public User Assignee { get; set; }
    public TicketStatus TicketStatus { get; set; }
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