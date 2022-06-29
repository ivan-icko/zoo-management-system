using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ZooloskiVrt.Server.SistemskeOperacije;
using ZooloskiVrt.Common.Domen;
using Moq;
using Autofac.Extras.Moq;
using ZooloskiVrt.Server.Repozitorujum;

namespace ZooloskiVrt.Server.SistemskeOperacije.Tests
{
    public class VratiSvePrijaveZaPosetiocePom : VratiSvePrijaveZaPosetioceSO
    {
        public VratiSvePrijaveZaPosetiocePom(IRepozitorijum<IDomenskiObjekat> mockRepository) : base()
        {
            this.repozitorijum = (IRepozitorijum<IDomenskiObjekat>)mockRepository;
        }
    }

    public class VratiSvePrijaveZaPosetioceSOTests
    {
        [Fact]
        public void VratiSvePrijaveZaPosetioce_Ok_Fact()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepozitorijum<IDomenskiObjekat>>()
                    .Setup(x => x.VratiSve(new PosetilacPrijava()))
                    .Returns(GetPrijave().OfType<IDomenskiObjekat>().ToList());


                VratiSvePrijaveZaPosetioceSO cls = new VratiSvePrijaveZaPosetiocePom(mock.Create<IRepozitorijum<IDomenskiObjekat>>());


                var expected = GetPrijave();
                var actual = cls.VratiPosetiocePrijava();


                Assert.True(actual != null);
                Assert.Equal(expected, actual);
            }
        }


        private List<PosetilacPrijava> GetPrijave()
        {
            return new List<PosetilacPrijava>()
            {
             new PosetilacPrijava()
             {
               ImeIPrezime = "Pera Peric"
             }
        };
           
           
        }



    }
}
