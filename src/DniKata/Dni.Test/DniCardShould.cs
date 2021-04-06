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
        [Theory]
        [InlineData("1234567A")]
        [InlineData("123456789A")]
        public void BeNoOtherThan9CharacersLong(string rawDNI)
        {
            Assert.Throws<ArgumentException>(() => 
                new DniCard(rawDNI));
        }
    }
}
