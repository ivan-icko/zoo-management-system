using Xunit;
using System;
using ZooloskiVrt.Common.Domen;

namespace UnitTestProject3
{
    
    public class ZaposleniTests
    {
        public readonly Zaposleni z;

        public ZaposleniTests()
        {
            z = new Zaposleni();
        }


        [Fact]
        public void SetIdZaposlenog_PositiveInt_Fact()
        {
            z.SetIdZaposlenog(1);
            Assert.Equal(1, z.GetIdZaposlenog());
        }

        [Fact]
        public void SetIdZaposlenog_NegativeInt_Fact()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => z.SetIdZaposlenog(-1));
        }





        [Fact]
        public void SetIme_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => z.SetIme(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void SetIme_Empty_Theory(string naziv)
        {
            Assert.Throws<ArgumentException>(() => z.SetIme(naziv));
        }

        [Theory]
        [InlineData("Pera")]
        [InlineData("Mika")]
        public void SetOk_Theory(string naziv)
        {
            z.SetIme(naziv);
            Assert.Equal(naziv, z.GetIme());
        }



        [Fact]
        public void SetPrezime_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => z.SetPrezime(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void SetImeIPrezime_Empty_Theory(string naziv)
        {
            Assert.Throws<ArgumentException>(() => z.SetPrezime(naziv));
        }

        [Theory]
        [InlineData("Peric")]
        [InlineData("Mikic")]
        public void SetPrezimeOk_Theory(string naziv)
        {
            z.SetPrezime(naziv);
            Assert.Equal(naziv, z.GetPrezime());
        }


        [Fact]
        public void SetKorisnickoIme_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => z.SetKorisnickoIme(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void SetKorisnickoIme_Empty_Theory(string naziv)
        {
            Assert.Throws<ArgumentException>(() => z.SetKorisnickoIme(naziv));
        }

        [Theory]
        [InlineData("Pera Peric")]
        [InlineData("Mika Mikic")]
        public void SetKorisnickoImeOk_Theory(string naziv)
        {
            z.SetKorisnickoIme(naziv);
            Assert.Equal(naziv, z.GetKorisnickoIme());
        }


        [Fact]
        public void SetSifra_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => z.SetSifra(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void SetSifra_Empty_Theory(string naziv)
        {
            Assert.Throws<ArgumentException>(() => z.SetSifra(naziv));
        }

        [Theory]
        [InlineData("Pera Peric")]
        [InlineData("Mika Mikic")]
        public void SetSifraOk_Theory(string naziv)
        {
            z.SetSifra(naziv);
            Assert.Equal(naziv, z.GetSifra());
        }





    }
}
