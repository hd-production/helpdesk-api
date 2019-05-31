using System.Collections.Generic;

namespace HdProduction.HelpDesk.Domain.Entities
{
  public class Ticket : EntityBase<long>
  {
    public Ticket(string issue, string details, string issuerEmail,
      long? assigneeId = null, int? priorityId = null, int? statusId = null, int? categoryId = null)
    {
      Issue = issue;
      Details = details;
      AssigneeId = assigneeId;
      IssuerEmail = issuerEmail;
      PriorityId = priorityId;
      StatusId = statusId;
      CategoryId = categoryId;
    }

    public string Issue { get; private set; }
    public string Details { get; private set; }
    public string IssuerEmail { get; private set; }
    public long? AssigneeId { get; private set; }
    public int? PriorityId { get; private set; }
    public int? StatusId { get; private set; }
    public int? CategoryId { get; private set; }

    public User Assignee { get; set; } // ef
    public TicketPriority Priority { get; set; } // ef
    public TicketStatus Status { get; set; } // ef
    public TicketCategory Category { get; set; } // ef
    public ICollection<Comment> Comments { get; set; } // ef
    public ICollection<TicketAction> Actions { get; set; } // ef
    public ICollection<TicketAttachment> Attachments { get; set; } // ef

    public void Update(string issue, string details, string issuerEmail,
      long? assigneeId, int? priorityId, int? statusId, int? categoryId)
    {
      Issue = issue;
      Details = details;
      AssigneeId = assigneeId;
      IssuerEmail = issuerEmail;
      PriorityId = priorityId;
      StatusId = statusId;
      CategoryId = categoryId;
    }
  }
}