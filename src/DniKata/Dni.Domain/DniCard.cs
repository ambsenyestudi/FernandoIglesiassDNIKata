using System;

namespace Dni.Domain
{
    public record DniCard
    {
        public DniCard(string rawDni)
        {
            if(rawDni != "12345678A")
            {
                throw new ArgumentException("");
            }
        }
    }
}
