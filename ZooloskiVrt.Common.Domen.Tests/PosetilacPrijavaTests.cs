using Xunit;
using System;
using ZooloskiVrt.Common.Domen;
using ZooloskiVrt.Common.Domen.Tests;

namespace UnitTestProject3
{
    
    public class PosetilacPrijavaTests:IDomenskiObjekatTests
    {
        public readonly PosetilacPrijava p;

        public PosetilacPrijavaTests()
        {
            p = new PosetilacPrijava();
        }

        
        [Fact]
        public void SetImeIPrezime_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => p.SetImeIPrezime(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void SetImeIPrezime_Empty_Theory(string naziv)
        {
            Assert.Throws<ArgumentException>(() => p.SetImeIPrezime(naziv));
        }

        [Theory]
        [InlineData("Ime1")]
        [InlineData("Ime2")]
        public void SetImeIPrezimeOk_Theory(string naziv)
        {
            p.SetImeIPrezime(naziv);
            Assert.Equal(naziv, p.GetImeIPrezime());
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
        [InlineData("Paket2")]
        public void SetNazivPaketaOk_Theory(string naziv)
        {
            p.SetNazivPaketa(naziv);
            Assert.Equal(naziv, p.GetNazivPaketa());
        }

        [Fact]
        public void SetTelefon_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => p.SetTelefon(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void SetTelefon_Empty_Theory(string naziv)
        {
            Assert.Throws<ArgumentException>(() => p.SetTelefon(naziv));
        }

        [Theory]
        [InlineData("011-25252")]
        [InlineData("011-055566")]
        public void SetTelefonOk_Theory(string naziv)
        {
            p.SetTelefon(naziv);
            Assert.Equal(naziv, p.GetTelefon());
        }





        [Fact]
        public void SetEmail_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => p.SetEmail(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void SetEmail_Empty_Theory(string naziv)
        {
            Assert.Throws<ArgumentException>(() => p.SetEmail(naziv));
        }

        [Theory]
        [InlineData("icko@gmail.com")]
        [InlineData("pera@gmail.com")]
        public void SetEmailOk_Theory(string naziv)
        {
            p.SetTelefon(naziv);
            Assert.Equal(naziv, p.GetTelefon());
        }


        [Fact]
        public void SetBrojOsoba_ZeroOfLess_Fact()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.SetBrojOsoba(-1));
        }


        [Fact]
        public void SetBrojOsoba_Ok_Fact()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.SetBrojOsoba(33));
        }

        [Fact]
        public void PosetilacPrijavaEquals_Ok_Fact()
        {
          PosetilacPrijava  p2 = new PosetilacPrijava() { ImeIPrezime = "Ivan Stepanovic", NazivPaketa = "Paket1" };

            p.ImeIPrezime = "Ivan Stepanovic";
            p.NazivPaketa = "Paket1";

            Assert.Equal(p, p2);
        }

        [Fact]
        public void PosetilacPrijavaNotEqual_Fact()
        {
            PosetilacPrijava p2 = new PosetilacPrijava() { ImeIPrezime = "Ivan Stepanovic", NazivPaketa = "Paket1" };

            p.ImeIPrezime = "Ivan Ivic";
            p.NazivPaketa = "Paket1";

            Assert.NotEqual(p, p2);
        }

        [Fact]
        public void ProcitajRed_Fact()
        {
            ido = new PosetilacPrijava()
            {
                NazivPaketa="Paket1",
                ImeIPrezime="Ivan Stepanovic"
            };
            ProcitajRedTest();
            Assert.Equal(ido, rez);
        }

    }
}
