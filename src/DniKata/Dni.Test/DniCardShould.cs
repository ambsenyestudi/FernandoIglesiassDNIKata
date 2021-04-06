using Dni.Domain;
using System;
using Xunit;

namespace Dni.Test
{
    public class DniCardShould
    {
        [Theory]
        [InlineData(null)]
        [InlineData(" ")]
        public void NotProcessEmptyString(string rawDNI)
        {
            Assert.Throws<ArgumentException>(() =>
                new DniCard(rawDNI));
        }
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

        [Fact]
        public void EndInLetter()
        {
            var dni = new DniCard("12345678A");
            Assert.NotNull(dni);
        }
        [Fact]
        public void EndInNoOtherThanLetter()
        {
            var wrongRawDNI = "123456780";
            Assert.Throws<ArgumentException>(() =>
                new DniCard(wrongRawDNI));
        }

        [Theory]
        [InlineData("12345B78A")]
        [InlineData("B1234578A")]
        [InlineData("BBAABBABA")]
        public void StartByNoOtherThan8Characers(string rawDNI)
        {
            Assert.Throws<ArgumentException>(() =>
                new DniCard(rawDNI));
        }

        [Theory]
        [InlineData("12345678U")]
        [InlineData("12345678I")]
        [InlineData("12345678O")]
        [InlineData("12345678Ñ")]
        public void NoEndInForbiddenLetters(string rawDNI)
        {
            Assert.Throws<ArgumentException>(() =>
                new DniCard(rawDNI));
        }
    }
}
