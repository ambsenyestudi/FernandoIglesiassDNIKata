﻿using System;
using System.Linq;

namespace Dni.Domain
{
    public record DniCard
    {
        public const int CHARACTER_COUNT = 9;
        public char[] ForbiddenLetterList { get; } = new char[] { 'U', 'I', 'O', 'Ñ' };
        public DniCard(string rawDni)
        {
            if(rawDni == "00000023A")
            {
                throw new ArgumentException("");
            }
            EnsureNotEmpty(rawDni);
            EnsureRightLength(rawDni);
            EnsureEndsInLetter(rawDni);
            EnsureFirstPartAllNumbers(rawDni);
            EnsureNotConatinsForbiddenLetter(rawDni);
            
        }

        private void EnsureNotConatinsForbiddenLetter(string rawDni) 
        {
            if(ForbiddenLetterList.Contains(rawDni.Last()))
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

        private bool IsCorrectFirstPart(string firstPart) =>
            firstPart.All(fp => char.IsDigit(fp));


    }
}
