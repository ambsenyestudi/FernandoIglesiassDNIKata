using System;
using System.Linq;

namespace Dni.Domain
{
    public record DNILetter
    {
        public char[] ForbiddenLetterList { get; } = new char[] { 'U', 'I', 'O', 'Ñ' };
        private const int LETTER_DIVIDER = 23;
        internal DNILetter(char letter)
        {
            
            EnsureEndsInLetter(letter);
            EnsureNotConatinsForbiddenLetter(letter);
        }

        public static bool TryParse(string rawDNI, out DNILetter letter)
        {
            var numberPart = rawDNI.Substring(0, rawDNI.Length - 1);
            if(!int.TryParse(numberPart, out int dniNumber))
            {
                letter = null;
                return false;
            }
            var correctLetter = FigureLetter(dniNumber);
            if (rawDNI.Last()!=correctLetter)
            {
                letter = null;
                return false;
            }
            letter = new DNILetter(rawDNI.Last());
            return true;
        }
        public static char FigureLetter(int dniNumber)
        {
            var index = dniNumber % LETTER_DIVIDER;
            var letterDefinition = ((DNILetterDefinitions)index);
            var letter = letterDefinition.ToString();
            return letter.First();
        }

        private void EnsureNotConatinsForbiddenLetter(char letter)
        {
            if (ForbiddenLetterList.Contains(letter))
            {
                throw new ArgumentException("");
            }
        }
        private void EnsureEndsInLetter(char letter)
        {
            if (!EndsInLetter(letter))
            {
                throw new ArgumentException("");
            }
        }
        private bool EndsInLetter(char letter) =>
           char.IsLetter(letter);
    }
}
