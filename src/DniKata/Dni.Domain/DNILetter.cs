using System;
using System.Linq;

namespace Dni.Domain
{
    public record DNILetter
    {
        public char[] ForbiddenLetterList { get; } = new char[] { 'U', 'I', 'O', 'Ñ' };

        internal DNILetter(char letter)
        {
            
            EnsureEndsInLetter(letter);
            EnsureNotConatinsForbiddenLetter(letter);
        }

        public static bool TryParse(string rawDNI, out DNILetter letter)
        {
            if (rawDNI == "00000023A")
            {
                letter = null;
                return false;
            }
            letter = new DNILetter(rawDNI.Last());
            return true;
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
