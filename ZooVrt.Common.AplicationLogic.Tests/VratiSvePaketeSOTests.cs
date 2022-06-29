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
    public class VratiSvePaketeSOPom : VratiSvePaketeSO
    {
        public VratiSvePaketeSOPom(IRepozitorijum<IDomenskiObjekat> mockRepository) : base()
        {
            this.repozitorijum = (IRepozitorijum<IDomenskiObjekat>)mockRepository;
        }
    }

    public class VratiSvePaketeTests
    {
        [Fact]
        public void VratiSvePakete_Ok_Fact()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepozitorijum<IDomenskiObjekat>>()
                    .Setup(x => x.VratiSve(new Paket()))
                    .Returns(GetZivotinje().OfType<IDomenskiObjekat>().ToList());

                
                VratiSvePaketeSO cls = new VratiSvePaketeSOPom(mock.Create<IRepozitorijum<IDomenskiObjekat>>());
                

                var expected = GetZivotinje();
                var actual = cls.VratiSvePakete();


                Assert.True(actual != null);
                Assert.Equal(expected.Count, actual.Count);
                Assert.Equal(expected, actual);
            }
        }


        private List<Paket> GetZivotinje()
        {
            return new List<Paket>()
            {
                new Paket()
                {
                    NazivPaketa="Paket1"
                }
            };
        }



    }
}
