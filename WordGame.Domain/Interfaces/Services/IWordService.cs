namespace WordGame.Domain.Interfaces.Services
{
   public interface IWordService
   {
      char[] GetRandomCharacters(int length = 12);

      string FormatString(char[] chars);

      Task<bool> IsValidWord(string word);

      bool IsWordInChars(char[] chars, string word);
   }
}