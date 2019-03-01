using System;
using System.IO;
using System.Reflection;
using HdProduction.HelpDesk.Infrastructure;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace HdProduction.Infrastructure.Sqlite
{
  public class ApplicationContextDesignFactory : IDesignTimeDbContextFactory<ApplicationContext>
  {
    private const string DefaultConnString = "Data Source=cftool.db";

    public ApplicationContext CreateDbContext(string[] args)
    {
      if (!File.Exists("appsettings.json"))
      {
        return TerminalMigrationsWorkaround();
      }

      IConfigurationRoot configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build();

      var msb = new SqliteConnectionStringBuilder(configuration.GetConnectionString("Db"));
      var options = new DbContextOptionsBuilder<ApplicationContext>()
        .UseSqlite(msb.ToString(), b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
      Console.WriteLine(msb.ToString());
      return new ApplicationContext(options.Options);
    }

    private static ApplicationContext TerminalMigrationsWorkaround()
    {
      var options = new DbContextOptionsBuilder<ApplicationContext>()
        .UseSqlite(DefaultConnString, b => b.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name));
      return new ApplicationContext(options.Options);
    }
  }
}