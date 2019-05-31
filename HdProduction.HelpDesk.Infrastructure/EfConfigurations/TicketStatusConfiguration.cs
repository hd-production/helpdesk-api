using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HdProduction.HelpDesk.Infrastructure.EfConfigurations
{
    public class TicketStatusConfiguration : EntityBaseConfiguration<TicketStatus, int>
    {
        protected override void ConfigureNext(EntityTypeBuilder<TicketStatus> builder)
        {
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(TicketStatus.MaxNameLength);
            builder.Property(s => s.Default);

            base.ConfigureNext(builder);
        }
    }
}