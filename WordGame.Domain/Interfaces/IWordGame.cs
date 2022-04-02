namespace WordGame.Domain.Interfaces
{
   public interface IWordGame
   {
      Task Start(double intervalInSeconds);

      void DisplayScore(int points);
   }
}