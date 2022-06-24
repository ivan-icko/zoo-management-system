using System;
using Xunit;
using ZooloskiVrt.Common.Domen;


namespace UnitTestProject3
{
    
    public class PaketZivotinjaTests
    {
        private readonly PaketZivotinja p;
        public PaketZivotinjaTests()
        {
             p = new PaketZivotinja();
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
        public void SetIdZivotinje_Positive_Fact()
        {
            p.SetIdZivotinje(2);
            Assert.Equal(2, p.GetIdZivotinje());
        }


        [Fact]
        public void SetIdZivotinje_Negative_Fact()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.SetIdZivotinje(-1));
        }


    }
}
