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

      builder.HasOne(t => t.Status)
        .WithMany(s => s.Tickets)
        .HasForeignKey(t => t.StatusId);

      builder.HasOne(t => t.Priority)
        .WithMany(p => p.Tickets)
        .HasForeignKey(t => t.PriorityId);

      base.ConfigureNext(builder);
    }
  }
}