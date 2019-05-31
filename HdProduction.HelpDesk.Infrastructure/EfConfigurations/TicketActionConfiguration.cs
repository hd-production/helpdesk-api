using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HdProduction.HelpDesk.Infrastructure.EfConfigurations
{
  public class TicketActionConfiguration : EntityBaseConfiguration<TicketAction, long>
  {
    protected override void ConfigureNext(EntityTypeBuilder<TicketAction> builder)
    {
      builder.Property(ta => ta.TicketId);
      builder.Property(ta => ta.UserId);
      builder.Property(ta => ta.Type);
      builder.Property(ta => ta.Time);

      builder.Property(ta => ta.OldAssigneeId);
      builder.Property(ta => ta.NewAssigneeId);
      builder.Property(ta => ta.OldStatusId);
      builder.Property(ta => ta.NewStatusId);
      builder.Property(ta => ta.CommentId);
      builder.Property(ta => ta.AttachmentKey);

      builder.HasOne(ta => ta.User)
        .WithMany(u => u.Actions)
        .HasForeignKey(ta => ta.UserId)
        .OnDelete(DeleteBehavior.Cascade);

      builder.HasOne(ta => ta.Ticket)
        .WithMany(t => t.Actions)
        .HasForeignKey(ta => ta.TicketId)
        .OnDelete(DeleteBehavior.Cascade);

      base.ConfigureNext(builder);
    }
  }
}