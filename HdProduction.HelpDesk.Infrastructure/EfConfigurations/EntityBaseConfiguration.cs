using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HdProduction.HelpDesk.Infrastructure.EfConfigurations
{
  public class EntityBaseConfiguration<T, TKey> : IEntityTypeConfiguration<T> where T : EntityBase<TKey> where TKey : struct
  {
    public void Configure(EntityTypeBuilder<T> builder)
    {
      builder.HasKey(p => p.Id);

      builder.Property(p => p.Id)
        .ValueGeneratedOnAdd();

      ConfigureNext(builder);
    }

    protected virtual void ConfigureNext(EntityTypeBuilder<T> builder)
    {
    }
  }
}