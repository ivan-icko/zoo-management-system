using Xunit;
using System;
using ZooloskiVrt.Common.Domen;
using ZooloskiVrt.Common.Domen.Tests;

namespace UnitTestProject3
{

    public class PrijavaTests:IDomenskiObjekatTests
    {
        public readonly Prijava p;
        public PrijavaTests()
        {
            p = new Prijava();
        }

        [Fact]
        public void SetPaketId_NegativeInt_Fact()
        {
          Assert.Throws<ArgumentOutOfRangeException>(() => p.SetIdPaketa(-1));
        }

        [Fact]
        public void SetPaketId_Ok_Fact()
        {
            p.SetIdPaketa(1);
            Assert.Equal(1,p.GetIdPaketa());
        }

        [Fact]
        public void SetIdPosetioca_NegativeInt_Fact()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.SetIdPosetioca(-1));
        }

        [Fact]
        public void SetIdPosetioca_Ok_Fact()
        {
            p.SetIdPaketa(1);
            Assert.Equal(1, p.GetIdPaketa());
        }

        [Theory]
        [InlineData("05/05/2005")]
        public void SetDatumPrijave_Past_Theory(DateTime datum)
        {
            DateTime date = Convert.ToDateTime(datum);
            Assert.Throws<ArgumentOutOfRangeException>(() => p.SetdDatumPrijave(datum));
        }

        [Theory]
        [InlineData("10/10/2022")]
        public void SetDatumPrijave_Ok_Theory(DateTime datum)
        {
            DateTime date = Convert.ToDateTime(datum);
            p.SetdDatumPrijave(datum);
            Assert.Equal(datum, p.GetDatumPrijave());
        }



        [Fact]
        public void SetBrojOsoba_ZeroOfLess_Fact()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => p.SetBrojOsoba(-1));
        }


        [Fact]
        public void SetBrojOsoba_Ok_Fact()
        {
            p.SetBrojOsoba(3);
            Assert.Equal(3, p.GetBrojOsoba());
        }


        [Fact]
        public void ProcitajRed_Fact()
        {
            ido = new Prijava()
            {
                IdPaketa=1,
                IdPosetioca=1
            };
            ProcitajRedTest();
            Assert.Equal(ido, rez);
        }

    }
}
