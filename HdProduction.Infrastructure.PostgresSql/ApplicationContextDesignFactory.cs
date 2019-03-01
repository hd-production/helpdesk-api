using System;
using System.IO;
using System.Reflection;
using HdProduction.HelpDesk.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace HdProduction.Infrastructure.PostgresSql
{
  public class ApplicationContextDesignFactory : IDesignTimeDbContextFactory<ApplicationContext>
  {
    private const string DefaultConnString = "Data Source=hd-helpdesk.db";

    public ApplicationContext CreateDbContext(string[] args)
    {
      if (!File.Exists("appsettings.json"))
      {
        return TerminalMigrationsWorkaround();
      }

      IConfigurationRoot configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

      var msb = new NpgsqlConnectionStringBuilder(configuration.GetConnectionString("Db"))
      {
        Database = new NpgsqlConnectionStringBuilder(configuration.GetConnectionString("Db")).Database
      };
      var options = new DbContextOptionsBuilder<ApplicationContext>()
        .UseNpgsql(msb.ToString(), b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
      Console.WriteLine(msb.ToString());
      return new ApplicationContext(options.Options);
    }

    private static ApplicationContext TerminalMigrationsWorkaround()
    {
      var options = new DbContextOptionsBuilder<ApplicationContext>()
        .UseNpgsql(DefaultConnString, b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
      return new ApplicationContext(options.Options);
    }
  }
}