using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HdProduction.HelpDesk.Infrastructure.EfConfigurations
{
  public class TicketAttachmentConfiguration : IEntityTypeConfiguration<TicketAttachment>
  {
    public void Configure(EntityTypeBuilder<TicketAttachment> builder)
    {
      builder.Property(a => a.TicketId);
      builder.Property(a => a.AttachmentKey).HasMaxLength(256);

      builder.HasKey(a => new {a.TicketId, a.AttachmentKey});

      builder.HasOne(a => a.Ticket)
        .WithMany(t => t.Attachments)
        .HasForeignKey(a => a.TicketId);
    }
  }
}