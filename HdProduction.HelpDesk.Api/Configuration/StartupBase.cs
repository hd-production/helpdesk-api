using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HdProduction.App.Common;
using HdProduction.App.Common.Auth;
using HdProduction.HelpDesk.Api.Auth;
using HdProduction.HelpDesk.Domain.Contract;
using HdProduction.HelpDesk.Domain.Safeguards;
using HdProduction.HelpDesk.Domain.Services;
using HdProduction.HelpDesk.Infrastructure;
using HdProduction.HelpDesk.Infrastructure.Repositories;
using HdProduction.HelpDesk.Infrastructure.Services;
using log4net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HdProduction.HelpDesk.Api.Configuration
{
    public abstract class CommonStartup
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        protected IConfiguration Configuration { get; }

        protected CommonStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddWebApi()
                .AddControllers()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

//            services.AddApiVersioning();

            services.AddScoped<ITicketsRepository, TicketsRepository>();
            services.AddScoped<ITicketStatusRepository, TicketStatusRepository>();
            services.AddScoped<ITicketStatusService, TicketStatusService>();
            services.AddScoped<ITicketService, TicketService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ISessionService, SessionsService>();
            services.AddScoped<ITokenService, JwtTokenService>(c => new JwtTokenService(Configuration.GetValue<string>("RsaKeysPath:Private")));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserSafeguard, UserSafeguard>();

            services.AddSingleton(AutoMapperConfig.Configure());

            services.AddJwtAuthentication(Configuration.GetValue<string>("RsaKeysPath:Public"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            Logger.Info("Application starting...");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            Task.Run(() => ConfigureDbAsync(app));
            app.UseMiddleware<ErrorHandlingMiddleware>();
            app.UseCors(Configuration);
            app.UseMvc();

            Logger.Info("Application is started");
        }

        protected virtual async Task ConfigureDbAsync(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                try
                {
                    var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();
                    var migrationsAssembly = context.GetService<IMigrationsAssembly>();

                    await context.Database.EnsureCreatedAsync();

                    var appliedMigrations = await context.Database.GetAppliedMigrationsAsync();
                    if (migrationsAssembly.Migrations.Any(m => !appliedMigrations.Contains(m.Key)))
                    {
                        await context.Database.MigrateAsync();
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}