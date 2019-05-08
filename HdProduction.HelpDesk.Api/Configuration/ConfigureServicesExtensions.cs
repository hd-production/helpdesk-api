using System.Reflection;
using HdProduction.HelpDesk.Api.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace HdProduction.HelpDesk.Api.Configuration
{
  public static class ConfigureServicesExtensions
  {
    public static IMvcCoreBuilder AddControllers(this IMvcCoreBuilder mvcCoreBuilder)
    {
      var controllersAssembly = typeof(HomeController).Assembly;
      return mvcCoreBuilder.AddApplicationPart(controllersAssembly).AddControllersAsServices();
    }
  }
}