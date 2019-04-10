using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HdProduction.HelpDesk.Infrastructure.EfConfigurations
{
  public class CommentConfiguration : EntityBaseConfiguration<Comment, long>
  {
    protected override void ConfigureNext(EntityTypeBuilder<Comment> builder)
    {
      builder.HasOne(up => up.User)
        .WithMany(u => u.Comments)
        .HasConstraintName("FK_Comments")
        .HasForeignKey(up => up.UserId)
        .OnDelete(DeleteBehavior.Cascade);

      builder.HasOne(up => up.Ticket)
        .WithMany(p => p.Comments)
        .HasForeignKey(up => up.TicketId)
        .HasConstraintName("FK_Tickets")
        .OnDelete(DeleteBehavior.Cascade);

      builder.Property(b => b.Text).HasMaxLength(512);

      base.ConfigureNext(builder);
    }
  }
}