using System.Collections.Generic;

namespace HdProduction.HelpDesk.Domain.Entities
{
  public class Ticket : EntityBase<long>
  {
<<<<<<< HEAD
    public Ticket(string issue, string details, string issuerEmail, long? assigneeId = null)
=======
    public Ticket(string issue, string details, long? assigneeId, int? priorityId, int? statusId, int? categoryId)
>>>>>>> df13df5a2229144c1cc0fe797fc7cf05db771883
    {
      Issue = issue;
      Details = details;
      AssigneeId = assigneeId;
<<<<<<< HEAD
      IssuerEmail = issuerEmail;
=======
      PriorityId = priorityId;
      StatusId = statusId;
      CategoryId = categoryId;
>>>>>>> df13df5a2229144c1cc0fe797fc7cf05db771883
    }

    public string Issue { get; }
    public string Details { get; }
    public string IssuerEmail { get; }
    public long? AssigneeId { get; }
<<<<<<< HEAD
    public long? TicketStatusId { get; }
    public User Assignee { get; set; }
    public TicketStatus TicketStatus { get; set; }
=======
    public int? PriorityId { get; }
    public int? StatusId { get; }
    public int? CategoryId { get; }
   
    public TicketPriority Priority { get; set; } // ef
    public TicketStatus Status { get; set; } // ef
    public TicketCategory Category { get; set; } // ef
>>>>>>> df13df5a2229144c1cc0fe797fc7cf05db771883
    public ICollection<Comment> Comments { get; set; } // ef
    public ICollection<TicketAction> Actions { get; set; } // ef
    public ICollection<TicketAttachment> Attachments { get; set; } // ef
  }
}