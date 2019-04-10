using HdProduction.HelpDesk.Domain.Entities;
using HdProduction.HelpDesk.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HdProduction.HelpDesk.Infrastructure.EfConfigurations
{
  public class UserConfiguration : EntityBaseConfiguration<User, long>
  {
    protected override void ConfigureNext(EntityTypeBuilder<User> builder)
    {
      builder.Property(p => p.Email)
        .IsRequired()
        .HasMaxLength(254);

      builder.Property(p => p.FirstName)
        .IsRequired()
        .HasMaxLength(128);

      builder.Property(p => p.LastName)
        .IsRequired()
        .HasMaxLength(128);

      builder.Property(p => p.PwdHash)
        .IsRequired();

      builder.Property(p => p.PwdSalt)
        .HasMaxLength(SecurityHelper.SaltLength)
        .IsFixedLength();

      builder.Property(p => p.RefreshToken)
        .HasMaxLength(SecurityHelper.RefreshTokenLength)
        .IsFixedLength();

      builder.Property(p => p.PermissionsRaw);

      base.ConfigureNext(builder);
    }
  }
}