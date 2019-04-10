using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HdProduction.HelpDesk.Infrastructure.EfConfigurations
{
  public class TicketConfiguration : EntityBaseConfiguration<Ticket, long>
  {
    protected override void ConfigureNext(EntityTypeBuilder<Ticket> builder)
    {
      builder.Property(t => t.Issue)
        .IsRequired()
        .HasMaxLength(256);

      builder.Property(t => t.Details)
        .IsRequired();

      builder.Property(t => t.AssigneeId);

      base.ConfigureNext(builder);
    }
  }
}