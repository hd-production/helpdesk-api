using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HdProduction.HelpDesk.Infrastructure.EfConfigurations
{
  public class CommentConfiguration : EntityBaseConfiguration<Comment, long>
  {
    protected override void ConfigureNext(EntityTypeBuilder<Comment> builder)
    {
      builder.ToTable("comments");
      
      // TODO

      base.ConfigureNext(builder);
    }
  }
}