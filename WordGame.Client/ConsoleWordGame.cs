using Microsoft.Extensions.Configuration;
using WordGame.Domain.Interfaces;
using WordGame.Domain.Interfaces.Services;

namespace WordGame.Client
{
   public class ConsoleWordGame : IWordGame
   {
      private readonly IWordService _wordService;
      private readonly IConfiguration _configuration;

      private static int _totalPoints = 0;
      private static List<string> _validWords = new List<string>();
      private static System.Timers.Timer _timer = new System.Timers.Timer();

      public ConsoleWordGame(IWordService wordService, IConfiguration configuration)
      {
         _wordService = wordService;
         _configuration = configuration;
      }

      public async Task Start()
      {
         _timer.Interval = (int.Parse(_configuration["GameTimeInSeconds"]) * 1000);
         _timer.Elapsed += (object source, System.Timers.ElapsedEventArgs e) => EndGame();
         _timer.Enabled = true;

         Console.WriteLine($"You have {_configuration["GameTimeInSeconds"] } seconds to guess some words from the following characters");
         Console.WriteLine("Type a word and press enter to continue");

         var randomChars = _wordService.GetRandomCharacters();
         Console.WriteLine(_wordService.FormatString(randomChars));

         do
         {
            var word = Console.ReadLine();
            await HandleWord(word, randomChars);
         } while (_timer.Enabled);
      }

      private void EndGame()
      {
         SetConsoleColor(ConsoleColor.Red);
         Console.WriteLine($"Time's up!\n");
         ResetConsoleColor();
         Environment.Exit(0);
      }

      private async Task HandleWord(string word, char[] randomChars)
      {
         if (_wordService.IsWordInChars(randomChars, word))
         {
            if (_validWords.Contains(word))
            {
               DisplayWordAlreadyEntered(); return;
            }
            var isValid = await _wordService.IsValidWord(word);
            if (!isValid)
            {
               DisplayInvalidWord(); return;
            }
            _totalPoints++;
            _validWords.Add(word);
            DisplayWordSuccess(_totalPoints);
         }
         else
            DisplayOutOfRangeCharacters();
      }

      public void DisplayScore(int points)
      {
         SetConsoleColor(ConsoleColor.Green);
         Console.WriteLine($"You scored {points}\n");
         ResetConsoleColor();
      }

      #region PrivateHelpers

      private void DisplayInvalidWord()
      {
         SetConsoleColor(ConsoleColor.Red);
         Console.WriteLine($"Invalid word pal :( but no problem keep trying\n");
         ResetConsoleColor();
      }

      private void DisplayOutOfRangeCharacters()
      {
         SetConsoleColor(ConsoleColor.Yellow);
         Console.WriteLine($"Please only use the characters up there to come up with a word :)\n");
         ResetConsoleColor();
      }

      private void DisplayWordSuccess(int totalPoints)
      {
         SetConsoleColor(ConsoleColor.Green);
         Console.WriteLine($"Wohoo you've got {totalPoints} points :D\n");
         ResetConsoleColor();
      }

      private void DisplayWordAlreadyEntered()
      {
         SetConsoleColor(ConsoleColor.Yellow);
         Console.WriteLine($"You've already used that word before ;)\n");
         ResetConsoleColor();
      }

      private static void SetConsoleColor(ConsoleColor consoleColor)
      {
         Console.ForegroundColor = consoleColor;
      }

      private static void ResetConsoleColor()
      {
         Console.ForegroundColor = ConsoleColor.White;
      }

      #endregion PrivateHelpers
   }
}