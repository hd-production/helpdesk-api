using HdProduction.HelpDesk.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HdProduction.HelpDesk.Infrastructure.EfConfigurations
{
  public class TicketConfiguration : EntityBaseConfiguration<Ticket, long>
  {
    protected override void ConfigureNext(EntityTypeBuilder<Ticket> builder)
    {
      builder.ToTable("tickets");

      base.ConfigureNext(builder);
    }
  }
}