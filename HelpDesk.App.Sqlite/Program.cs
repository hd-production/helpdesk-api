using System.Threading.Tasks;
using HdProduction.HelpDesk.Api;

namespace HelpDesk.App.Sqlite
{
    public class Program
    {
        public static Task Main(string[] args)
        {
            return ProgramStart.RunAsync<Startup>(args);
        }
    }
}