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
        .HasForeignKey(up => up.UserId)
        .OnDelete(DeleteBehavior.Cascade);

      builder.HasOne(up => up.Ticket)
        .WithMany(p => p.Comments)
        .HasForeignKey(up => up.TicketId)
        .OnDelete(DeleteBehavior.Cascade);
      
      builder.HasMany(up => up.Replies)
        .WithOne(p => p.Parent)
        .HasForeignKey(up => up.ReplyToComment)
        .OnDelete(DeleteBehavior.Cascade);

      builder.Property(b => b.Text).HasMaxLength(512);

      base.ConfigureNext(builder);
    }
  }
}