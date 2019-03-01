using HdProduction.HelpDesk.Api.Configuration;
using HdProduction.HelpDesk.Infrastructure;
using HdProduction.Infrastructure.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HelpDesk.App.Sqlite
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
                options.UseSqlite(Configuration.GetConnectionString("Db"),
                b => b.MigrationsAssembly(typeof(ApplicationContextDesignFactory).Assembly.FullName)));
        }
    }
}