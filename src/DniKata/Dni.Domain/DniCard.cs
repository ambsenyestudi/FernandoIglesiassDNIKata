using System;
using System.Linq;

namespace Dni.Domain
{
    public record DniCard
    {
        public const int CHARACTER_COUNT = 9;
        public DniCard(string rawDni)
        {
            if(!IsRightLength(rawDni) || !EndInLetter(rawDni))
            {
                throw new ArgumentException("");
            }
        }

        private bool EndInLetter(string rawDni) =>
            char.IsLetter(rawDni.Last());

        private bool IsRightLength(string rawDni) =>
            rawDni.Length == CHARACTER_COUNT;
    }
}
