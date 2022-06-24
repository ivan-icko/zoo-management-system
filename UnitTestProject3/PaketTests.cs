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

        [Theory]
        [InlineData("Paket1")]
        [InlineData("Paket3")]
        public void SetNazivPaketaOk_Theory(string naziv)
        {
            p.SetNazivPaketa(naziv);
            Assert.Equal(naziv, p.GetNazivPaketa());
        }


        [Fact]
        public void SetCena_NegativeInt_Fact()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.SetCena(-1));
        }

        [Fact]
        public void SetCena_PositiveInt_Fact()
        {
            p.SetCena(2);
            Assert.Equal(2, p.GetCena());
        }


        [Theory]
        [InlineData("05/05/2005")]
        public void SetDatumDo_Past_Theory(DateTime datum)
        {
            DateTime date = Convert.ToDateTime(datum);
            Assert.Throws<ArgumentOutOfRangeException>(() => p.SetdDatumDo(datum));
        }

        [Theory]
        [InlineData("10/10/2022")]
        public void SetDatumDo_Ok_Theory(DateTime datum)
        {
            DateTime date = Convert.ToDateTime(datum);
            p.SetdDatumDo(datum);
            Assert.Equal(datum, p.GetDatumDo());
        }








    }
}
