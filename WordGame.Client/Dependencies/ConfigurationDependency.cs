using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace WordGame.Client.Dependencies
{
   public static class ConfigurationDependency
   {
      public static IHostBuilder RegisterConfiguration(this IHostBuilder builder)
      {
         builder.ConfigureAppConfiguration(app =>
       {
          app.AddJsonFile("appsettings.json");
       });
         return builder;
      }
   }
}
