using HdProduction.HelpDesk.Api.Configuration;
using HdProduction.HelpDesk.Infrastructure;
using HdProduction.Infrastructure.PostgresSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDesk.App.Global
{
  public class Startup : CommonStartup
  {
    public Startup(IConfiguration configuration) : base(configuration)
    {
    }

    public override void ConfigureServices(IServiceCollection services)
    {
      base.ConfigureServices(services);

      services.AddDbContext<ApplicationContext>(options =>
        options.UseNpgsql(Configuration.GetConnectionString("Db"),
          b => b.MigrationsAssembly(typeof(ApplicationContextDesignFactory).Assembly.FullName)));
    }
  }
}