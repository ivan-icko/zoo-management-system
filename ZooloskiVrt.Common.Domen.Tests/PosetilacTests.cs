using Xunit;
using System;
using ZooloskiVrt.Common.Domen;

namespace UnitTestProject3
{
    
    public class PosetilacTests
    {
        private readonly Posetilac p;
        public PosetilacTests()
        {
            p = new Posetilac();
        }
        
        [Fact]
        public void SetPosetilacId_PositiveInt_Fact()
        {
            p.SetIdPosetioca(1);
            Assert.Equal(1,p.GetIdPosetioca());
        }

        [Fact]
        public void SetPosetilacId_NegativeInt_Fact()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.SetIdPosetioca(-1));
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
        [InlineData("Pera Peric")]
        [InlineData("Mika Mikic")]
        public void SetImeIPrezimeOk_Theory(string naziv)
        {
            p.SetImeIPrezime(naziv);
            Assert.Equal(naziv, p.GetImeIPrezime());
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
        [InlineData("011-335002")]
        [InlineData("011-558778")]
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
        [InlineData("miki@gmail.com")]
        public void SetEmailOk_Theory(string naziv)
        {
            p.SetEmail(naziv);
            Assert.Equal(naziv, p.GetEmail());
        }



        [Fact]
        public void PosetilacEquals_Ok_Fact()
        {
            Posetilac p2 = new Posetilac() { IdPosetioca = 1 };

            p.IdPosetioca = 1;

            Assert.Equal(p, p2);
        }

        [Fact]
        public void PosetilacNotEquals_Fact()
        {
            Posetilac p2 = new Posetilac() { IdPosetioca = 1 };

            p.IdPosetioca = 2;

            Assert.NotEqual(p, p2);
        }


    }
}
