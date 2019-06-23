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
      builder.Property(u => u.Email)
        .IsRequired()
        .HasMaxLength(254);

      builder.Property(u => u.FirstName)
        .IsRequired()
        .HasMaxLength(128);

      builder.Property(u => u.LastName)
        .IsRequired()
        .HasMaxLength(128);

      builder.Property(u => u.PwdHash)
        .IsRequired();

      builder.Property(u => u.PwdSalt)
        .HasMaxLength(SecurityHelper.SaltLength)
        .IsFixedLength();

      builder.Property(u => u.RefreshToken)
        .HasMaxLength(SecurityHelper.RefreshTokenLength)
        .IsFixedLength();

      builder.Property(u => u.PermissionsRaw);

      builder.Property(u => u.ProjectId).IsRequired();

      base.ConfigureNext(builder);
    }
  }
}