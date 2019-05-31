using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HdProduction.HelpDesk.Infrastructure.EfConfigurations
{
    public class TicketCategoryConfiguration : EntityBaseConfiguration<TicketCategory, int>
    {
        protected override void ConfigureNext(EntityTypeBuilder<TicketCategory> builder)
        {
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(TicketCategory.MaxNameLength);
            builder.Property(s => s.Default);

            base.ConfigureNext(builder);
        }
    }
}