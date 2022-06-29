using Xunit;
using System;
using ZooloskiVrt.Common.Domen;

namespace UnitTestProject3
{
    
    public class ZivotinjaTests
    {
        public readonly Zivotinja z;

        public ZivotinjaTests()
        {
            z = new Zivotinja();
        }
       


        [Fact]
        public void SetOznaka_PositiveInt_Fact()
        {
            z.SetOznakaZivotinje(1);
            Assert.Equal(1, z.GetOznakaZivotinje());
        }

        [Fact]
        public void SetOznaka_NegativeInt_Fact()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => z.SetOznakaZivotinje(-1));
        }


        [Fact]
        public void SetStaniste_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => z.SetStaniste(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void SetStaniste_Empty_Theory(string naziv)
        {
            Assert.Throws<ArgumentException>(() => z.SetStaniste(naziv));
        }

        [Theory]
        [InlineData("Macka")]
        [InlineData("Tigar")]
        public void SetStanisteOk_Theory(string naziv)
        {
            z.SetStaniste(naziv);
            Assert.Equal(naziv, z.GetStaniste());
        }

        [Fact]
        public void SetIdZivotinje_PositiveInt_Fact()
        {
            z.SetIdZivotinje(1);
            Assert.Equal(1, z.GetIdZivotinje());
        }

        [Fact]
        public void SetIdZivotinje_NegativeInt_Fact()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => z.SetIdZivotinje(-1));
        }




        [Fact]
        public void SetVrsta_Null_Fact()
        {
            Assert.Throws<ArgumentNullException>(() => z.SetVrsta(null));
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        public void SetIme_Empty_Theory(string naziv)
        {
            Assert.Throws<ArgumentException>(() => z.SetVrsta(naziv));
        }

        [Theory]
        [InlineData("Macka")]
        [InlineData("Tigar")]
        public void SetOk_Theory(string naziv)
        {
            z.SetVrsta(naziv);
            Assert.Equal(naziv, z.GetVrsta());
        }

        [Fact]
        public void SetStarost_PositiveInt_Fact()
        {
            z.SetStarost(1);
            Assert.Equal(1, z.GetStarost());
        }

        [Fact]
        public void SetStarost_NegativeInt_Fact()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => z.SetStarost(-1));
        }


    }
}
