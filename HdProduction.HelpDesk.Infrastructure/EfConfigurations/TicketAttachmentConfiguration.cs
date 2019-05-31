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
      builder.Property(a => a.Url).HasMaxLength(TicketAttachment.MaxUrlLength);

      builder.HasKey(a => a.Key);

      builder.HasOne(a => a.Ticket)
        .WithMany(t => t.Attachments)
        .HasForeignKey(a => a.TicketId);
    }
  }
}