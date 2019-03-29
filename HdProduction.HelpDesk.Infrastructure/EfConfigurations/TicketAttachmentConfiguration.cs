using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HdProduction.HelpDesk.Infrastructure.EfConfigurations
{
  public class TicketAttachmentConfiguration
  {
    public void Configure(EntityTypeBuilder<TicketAttachment> builder)
    {
      builder.HasKey(p => new {p.TicketId, p.AttachmentKey});

      builder.Property(p => p.TicketId);
      builder.Property(p => p.AttachmentKey)
        .HasMaxLength(256);
    }
  }
}