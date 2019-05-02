using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HdProduction.HelpDesk.Infrastructure.EfConfigurations
{
  public class CommentConfiguration : EntityBaseConfiguration<Comment, long>
  {
    protected override void ConfigureNext(EntityTypeBuilder<Comment> builder)
    {
      builder.HasOne(c => c.User)
        .WithMany(u => u.Comments)
        .HasForeignKey(c => c.UserId)
        .OnDelete(DeleteBehavior.Cascade);

      builder.HasOne(c => c.Ticket)
        .WithMany(t => t.Comments)
        .HasForeignKey(up => up.TicketId)
        .OnDelete(DeleteBehavior.Cascade);
      
      builder.HasMany(c => c.Replies)
        .WithOne(c => c.Parent)
        .HasForeignKey(c => c.ReplyToCommentId)
        .OnDelete(DeleteBehavior.Cascade);

      builder.Property(c => c.CreatedAt);

      builder.Property(c => c.Text).HasMaxLength(512);

      base.ConfigureNext(builder);
    }
  }
}