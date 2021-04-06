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
            EnsureEndsInLetter(rawDni);
            
            
        }

        private void EnsureEndsInLetter(string rawDni)
        {
            if (!EndsInLetter(rawDni))
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

        private bool EndsInLetter(string rawDni) =>
            char.IsLetter(rawDni.Last());

        
    }
}
