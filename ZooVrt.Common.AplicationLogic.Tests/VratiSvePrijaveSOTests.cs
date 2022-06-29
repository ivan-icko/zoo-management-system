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
    public class VratiSvePrijaveSOPom : VratiSvePrijaveSO
    {
        

        public VratiSvePrijaveSOPom(IRepozitorijum<IDomenskiObjekat> mockRepository) : base()
        {
            this.repozitorijum = (IRepozitorijum<IDomenskiObjekat>)mockRepository;
        }
      
    }

    public class VratiSvePrijaveSOTests
    {
        [Fact]
        public void VratiSvePrijave_Ok_Fact()
        {
            using (var mock = AutoMock.GetLoose())
            {
                
                mock.Mock<IRepozitorijum<IDomenskiObjekat>>()
                    .Setup(x => x.VratiSve(new Prijava()))
                    .Returns(GetPrijave().OfType<IDomenskiObjekat>().ToList());


                VratiSvePrijaveSO cls = new VratiSvePrijaveSOPom(mock.Create<IRepozitorijum<IDomenskiObjekat>>());


                var expected = GetPrijave();
                var actual = cls.VratiSvePrijave();


                Assert.True(actual != null);
                Assert.Equal(expected.Count, actual.Count);
                Assert.Equal(expected, actual);
            }
        }


        private List<Prijava> GetPrijave()
        {
            return new List<Prijava>()
            {
                new Prijava()
                {
                    BrojOsoba=3
                }
            };
        }



    }
}
