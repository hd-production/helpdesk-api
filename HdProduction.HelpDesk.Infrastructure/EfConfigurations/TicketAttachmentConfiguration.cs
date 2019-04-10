using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HdProduction.HelpDesk.Infrastructure.EfConfigurations
{
  public class TicketAttachmentConfiguration : IEntityTypeConfiguration<TicketAttachment>
  {
    public void Configure(EntityTypeBuilder<TicketAttachment> builder)
    {
      builder.Property(p => p.TicketId);
      builder.Property(p => p.AttachmentKey).HasMaxLength(256);

      builder.HasKey(p => new {p.TicketId, p.AttachmentKey});

      builder.HasOne(a => a.Ticket)
        .WithMany(t => t.Attachments)
        .HasForeignKey(a => a.TicketId);
    }
  }
}