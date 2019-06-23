using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HdProduction.HelpDesk.Infrastructure.EfConfigurations
{
    public class ProjectConfiguration : EntityBaseConfiguration<Project, long>
    {
        protected override void ConfigureNext(EntityTypeBuilder<Project> builder)
        {
            builder.Property(p => p.DashboardId);
            builder.Property(p => p.Name).IsRequired();
            
            base.ConfigureNext(builder);
        }
    }
}