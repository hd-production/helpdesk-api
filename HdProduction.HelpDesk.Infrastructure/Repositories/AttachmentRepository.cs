using System;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Entities;

namespace HdProduction.HelpDesk.Infrastructure.Repositories
{
  public class AttachmentRepository : RepositoryBase<TicketAttachment, Guid>, IAttachmentRepository
  {
    public AttachmentRepository(ApplicationContext context) : base(context)
    {
    }
  }
}