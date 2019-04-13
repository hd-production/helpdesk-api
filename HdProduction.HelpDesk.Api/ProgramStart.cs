using System.Threading.Tasks;
using HdProduction.App.Common.Logging;
using HdProduction.HelpDesk.Api.Configuration;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace HdProduction.HelpDesk.Api
{
    public static class ProgramStart
    {
        public static Task RunAsync<TStartup>(string[] args) where TStartup : CommonStartup
        {
            return CreateWebHostBuilder<TStartup>(args).Build().RunAsync();
        }

        private static IWebHostBuilder CreateWebHostBuilder<TStartup>(string[] args)
            where TStartup : class =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseUrls("http://0.0.0.0:5001")
                .ConfigureLogging((hostingContext, logging) => logging.AddLog4Net())
                .UseStartup<TStartup>()
                .CaptureStartupErrors(true);
    }
}