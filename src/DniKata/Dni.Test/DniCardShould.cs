using Dni.Domain;
using System;
using Xunit;

namespace Dni.Test
{
    public class DniCardShould
    {
        [Fact]
        public void Be9CharacersLong()
        {
            var dni = new DniCard("12345678A");
            Assert.NotNull(dni);
        }
    }
}
