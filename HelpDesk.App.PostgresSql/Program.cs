using System.Threading.Tasks;
using HdProduction.HelpDesk.Api;

namespace HelpDesk.App.PostgresSql
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            return ProgramStart.RunAsync<Startup>(args);
        }
    }
}