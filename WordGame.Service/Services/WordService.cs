using WordGame.Domain.Interfaces.ApiHandlers;
using WordGame.Domain.Interfaces.Services;

namespace WordGame.Service.Services
{
   public class WordService : IWordService
   {
      private readonly IDictionaryApiHandler _dictionaryApiHandler;

      public WordService(IDictionaryApiHandler dictionaryApiHandler)
      {
         _dictionaryApiHandler = dictionaryApiHandler;
      }

      public string FormatString(char[] chars) => string.Join(',', chars).Replace(",", ", ");

      public char[] GetRandomCharacters(int length = 12)
      {
         Random random = new Random();
         string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToLower();
         return Enumerable.Repeat(chars, length)
           .Select(s => s[random.Next(s.Length)]).ToArray();
      }

      public Task<bool> IsValidWord(string word) => _dictionaryApiHandler.IsValidWord(word.ToLower());

      public bool IsWordInChars(char[] chars, string word) => chars.Intersect(word.ToLower().ToCharArray()).Any();
   }
}