using System.Net.Mail;
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
    public DbSet<TicketStatus> TicketStatuses { get; set; }
    public DbSet<TicketPriority> TicketPriorities { get; set; }
    public DbSet<TicketCategory> TicketCategories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<TicketAttachment> Attachments { get; set; }
    public DbSet<TicketAction> Actions { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new TicketConfiguration());
      modelBuilder.ApplyConfiguration(new CommentConfiguration());
      modelBuilder.ApplyConfiguration(new TicketAttachmentConfiguration());
      modelBuilder.ApplyConfiguration(new TicketActionConfiguration());
      modelBuilder.ApplyConfiguration(new UserConfiguration());
      modelBuilder.ApplyConfiguration(new TicketStatusConfiguration());
      modelBuilder.ApplyConfiguration(new TicketPriorityConfiguration());
      modelBuilder.ApplyConfiguration(new TicketCategoryConfiguration());

      base.OnModelCreating(modelBuilder);
    }
  }
}