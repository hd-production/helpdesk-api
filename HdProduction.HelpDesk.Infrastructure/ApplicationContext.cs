using HdProduction.HelpDesk.Domain.Entities;
using HdProduction.HelpDesk.Infrastructure.EfConfigurations;
using Microsoft.EntityFrameworkCore;

namespace HdProduction.HelpDesk.Infrastructure
{
  public class ApplicationContext : DbContext
  {
    public ApplicationContext(DbContextOptions opt) : base(opt)
    {
    }

    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new TicketConfiguration());

      base.OnModelCreating(modelBuilder);
    }
  }
}