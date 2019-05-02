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

      builder.HasOne(e => e.Assignee)
        .WithMany(e => e.Tickets);

      builder.Property(t => t.Details)
        .IsRequired();

      builder.Property(t => t.AssigneeId);
      builder.Property(t => t.IssuerEmail);

      base.ConfigureNext(builder);
    }
  }
}