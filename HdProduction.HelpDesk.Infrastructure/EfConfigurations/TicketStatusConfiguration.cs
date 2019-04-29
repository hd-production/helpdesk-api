using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HdProduction.HelpDesk.Infrastructure.EfConfigurations
{
    public class TicketStatusConfiguration : EntityBaseConfiguration<TicketStatus, long>
    {
        protected override void ConfigureNext(EntityTypeBuilder<TicketStatus> builder)
        {
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(32);
            
            base.ConfigureNext(builder);
        }
    }
}