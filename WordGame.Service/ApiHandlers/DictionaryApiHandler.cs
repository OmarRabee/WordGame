using Microsoft.Extensions.Configuration;
using WordGame.Domain.Interfaces.ApiHandlers;

namespace WordGame.Service.ApiHandlers
{
   public class DictionaryApiHandler : IDictionaryApiHandler
   {
      private readonly HttpClient _dictionaryClient;

      public DictionaryApiHandler(IConfiguration configuration)
      {
         _dictionaryClient = new HttpClient() { BaseAddress = new Uri(configuration["DictionaryApiBase"]) };
      }

      public async Task<bool> IsValidWord(string word)
      {
         try
         {
            var result = await _dictionaryClient.GetAsync(word);
            return result.IsSuccessStatusCode;
         }
         catch (Exception e)
         {
            Console.WriteLine(e.Message);
            return false;
         }
      }
   }
}