using Microsoft.Extensions.DependencyInjection;
using WordGame.Domain.Interfaces;
using WordGame.Domain.Interfaces.Services;
using WordGame.Service.Services;

namespace WordGame.Client.Dependencies
{
   public static class ServiceDependency
   {
      public static IServiceCollection RegisterServices(this IServiceCollection services)
      {
         services
         .AddTransient<IWordService, WordService>()
         .AddTransient<IWordGame, ConsoleWordGame>();
         return services;
      }
   }
}