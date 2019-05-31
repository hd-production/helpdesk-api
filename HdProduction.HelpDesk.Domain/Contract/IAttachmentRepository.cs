using System;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Domain.Contract
{
  public interface IAttachmentRepository : IRepository<TicketAttachment, Guid>
  {
  }
}