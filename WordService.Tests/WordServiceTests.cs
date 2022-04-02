using Moq;
using WordGame.Domain.Interfaces.ApiHandlers;
using WordGame.Domain.Interfaces.Services;
using WordGame.Service.Services;
using Xunit;

namespace WordServiceTests
{
   public class WordServiceTests
   {
      Mock<IDictionaryApiHandler> _ApiHandlerMoq = new Mock<IDictionaryApiHandler>();
      IWordService _wordService;

      public WordServiceTests()
      {
         _wordService = new WordService(_ApiHandlerMoq.Object);
      }

      [Fact]
      public void IsWordInChars_Success_ReturnsTrue()
      {
         // Arrange
         var chars = new char[] { 'x', 'z', 'w', 'o', 'r', 'd' };
         var word = "word";

         // Act
         var actual = _wordService.IsWordInChars(chars, word);

         // Assert
         Assert.True(actual);
      }

      [Fact]
      public void IsWordInChars_Success_ReturnsFalse()
      {
         // Arrange
         var chars = new char[] { 'x', 'o', 'r', 'd' };
         var word = "word";

         // Act
         var actual = _wordService.IsWordInChars(chars, word);

         // Assert
         Assert.False(actual);
      }
   }
}