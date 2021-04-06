using System;
using System.Linq;

namespace Dni.Domain
{
    public record DniCard
    {
        public const int CHARACTER_COUNT = 9;
        
        public DniCard(string rawDni)
        {
            
            EnsureNotEmpty(rawDni);
            EnsureRightLength(rawDni);
            EnsureFirstPartAllNumbers(rawDni);
            if(!DNILetter.TryParse(rawDni, out DNILetter letter))
            {
                throw new ArgumentException("");
            }
            
        }

       

        //Cannot be les than 8 long becouse is check int EnsureRightLength
        private void EnsureFirstPartAllNumbers(string rawDni)
        {
            var firstPart = rawDni.Substring(0, rawDni.Length - 1);
            if(!IsCorrectFirstPart(firstPart))
            {
                throw new ArgumentException("");
            }
        }

        

       

        private void EnsureNotEmpty(string rawDni)
        {
            if (string.IsNullOrWhiteSpace(rawDni))
            {
                throw new ArgumentException("");
            }
        }

        private void EnsureRightLength(string rawDni)
        {
            if(!IsRightLength(rawDni))
            {
                throw new ArgumentException("");
            }
        }

        private bool IsRightLength(string rawDni) =>
            rawDni.Length == CHARACTER_COUNT;

        

        private bool IsCorrectFirstPart(string firstPart) =>
            firstPart.All(fp => char.IsDigit(fp));


    }
}
