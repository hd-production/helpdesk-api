using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HdProduction.HelpDesk.Infrastructure.EfConfigurations
{
    public class TicketPriorityConfiguration : EntityBaseConfiguration<TicketPriority, int>
    {
        protected override void ConfigureNext(EntityTypeBuilder<TicketPriority> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(32);
            
            base.ConfigureNext(builder);
        }
    }
}