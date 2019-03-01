using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace HdProduction.HelpDesk.Api.Configuration
{
  public static class ConfigureServicesExtensions
  {
    public static IMvcCoreBuilder AddControllers(this IMvcCoreBuilder mvcCoreBuilder)
    {
      var controllersAssembly = Assembly.Load("HdProduction.HelpDesk.Api");
      return mvcCoreBuilder.AddApplicationPart(controllersAssembly).AddControllersAsServices();
    }
  }
}