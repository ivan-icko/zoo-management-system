using System;
using ZooloskiVrt.Common.Domen;
using Xunit;


namespace UnitTestProject3
{
    
    public class PaketTests
    {
        private readonly Paket p;

        public PaketTests()
        {
            p = new Paket();
        }

        [Fact]
        public void SetPaketId_PositiveInt_Fact()
        {
            p.SetIdPaketa(2);
            Assert.Equal(2, p.GetIdPaketa());
        }

        [Fact]
        public void SetPaketId_NegativeInt_Fact()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.SetIdPaketa(-1));
        }

        [Fact]
        public void SetNazivPaketa_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => p.SetNazivPaketa(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void SetNazivPaketa_Empty_Theory(string naziv)
        {
            Assert.Throws<ArgumentException>(() => p.SetNazivPaketa(naziv));
        }




    }
}
