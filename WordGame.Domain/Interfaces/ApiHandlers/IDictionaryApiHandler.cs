namespace WordGame.Domain.Interfaces.ApiHandlers
{
   public interface IDictionaryApiHandler
   {
      Task<bool> IsValidWord(string word);
   }
}