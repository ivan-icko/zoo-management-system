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
    public class VratiZivotinjeZaPaketePom : VratiZivotinjeZaPaketeSO
    {
        public VratiZivotinjeZaPaketePom(IRepozitorijum<IDomenskiObjekat> mockRepository) : base()
        {
            this.repozitorijum = (IRepozitorijum<IDomenskiObjekat>)mockRepository;
        }
    }

    public class VratiSveZivotinjeZaPaketeSOTests
    {
        [Fact]
        public void VratiSveZivotinjeZaPakete_Ok_Fact()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Zivotinja z = new Zivotinja();

                mock.Mock<IRepozitorijum<IDomenskiObjekat>>()
                    .Setup(x => x.VratiSve(z))
                    .Returns(GetZivotinje().OfType<IDomenskiObjekat>().ToList());


                VratiZivotinjeZaPaketeSO cls = new VratiZivotinjeZaPaketePom(mock.Create<IRepozitorijum<IDomenskiObjekat>>());


                var expected = GetZivotinje();
                cls.zivotinja = z;
                var actual = cls.VratiSveZivotinjeZaPakete();


                Assert.True(actual != null);
                Assert.Equal(expected.Count, actual.Count);
                Assert.Equal(expected, actual);
            }
        }


        private List<Zivotinja> GetZivotinje()
        {
            return new List<Zivotinja>()
            {
                new Zivotinja()
                {
                   Vrsta="Zebra"
                }
            };
        }



    }
}
