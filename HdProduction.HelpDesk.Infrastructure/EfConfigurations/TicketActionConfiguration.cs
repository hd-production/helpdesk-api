using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HdProduction.HelpDesk.Infrastructure.EfConfigurations
{
  public class TicketActionConfiguration : EntityBaseConfiguration<TicketAction, long>
  {
    protected override void ConfigureNext(EntityTypeBuilder<TicketAction> builder)
    {
      builder.Property(b => b.TicketId);
      builder.Property(b => b.UserId);
      builder.Property(b => b.Type);
      builder.Property(b => b.Time);

      builder.Property(b => b.OldAssigneeId);
      builder.Property(b => b.NewAssigneeId);
      builder.Property(b => b.OldStatusId);
      builder.Property(b => b.NewStatusId);
      builder.Property(b => b.CommentId);

      builder.HasOne(up => up.User)
        .WithMany(u => u.Actions)
        .HasForeignKey(up => up.UserId)
        .OnDelete(DeleteBehavior.Cascade);

      builder.HasOne(up => up.Ticket)
        .WithMany(p => p.Actions)
        .HasForeignKey(up => up.TicketId)
        .OnDelete(DeleteBehavior.Cascade);

      base.ConfigureNext(builder);
    }
  }
}