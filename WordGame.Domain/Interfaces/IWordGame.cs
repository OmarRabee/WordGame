namespace WordGame.Domain.Interfaces
{
   public interface IWordGame
   {
      Task Start();

      void DisplayScore(int points);
   }
}