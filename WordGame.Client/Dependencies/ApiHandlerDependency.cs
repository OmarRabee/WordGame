using Microsoft.Extensions.DependencyInjection;
using WordGame.Domain.Interfaces.ApiHandlers;
using WordGame.Service.ApiHandlers;

namespace WordGame.Client.Dependencies
{
   public static class ApiHandlerDependency
   {
      public static IServiceCollection RegisterApiHadndlers(this IServiceCollection services)
      {
         services.AddTransient<IDictionaryApiHandler, DictionaryApiHandler>();
         return services;
      }
   }
}
