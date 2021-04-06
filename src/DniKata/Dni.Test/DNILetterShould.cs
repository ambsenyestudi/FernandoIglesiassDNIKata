using Dni.Domain;
using Xunit;

namespace Dni.Test
{
    public class DNILetterShould
    {
        [Theory]
        [InlineData(23, DNILetterDefinitions.T)]
        [InlineData(47, DNILetterDefinitions.R)]
        [InlineData(25, DNILetterDefinitions.W)]
        [InlineData(26, DNILetterDefinitions.A)]
        [InlineData(27, DNILetterDefinitions.G)]
        [InlineData(28, DNILetterDefinitions.M)]
        public void ParseLetter(int input, DNILetterDefinitions expectedDefinition)
        {
            var expectedLetter = expectedDefinition.ToString();
            var result = DNILetter.FigureLetter(input).ToString();
            Assert.Equal(expectedLetter, result);

        }
    }
}
