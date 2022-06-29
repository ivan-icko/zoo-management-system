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
    public class PronadjiZaposlenogPom : PronadjiZaposlenogSO
    {
        public PronadjiZaposlenogPom(IRepozitorijum<IDomenskiObjekat> mockRepository) : base()
        {
            this.repozitorijum = (IRepozitorijum<IDomenskiObjekat>)mockRepository;
        }
    }

    public class VratiSveZivotinjeTests
    {
        [Fact]
        public void VratiSveZivotinje_Ok_Fact()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepozitorijum<IDomenskiObjekat>>()
                    .Setup(x => x.VratiSve(new Zivotinja()))
                    .Returns(GetZivotinje().OfType<IDomenskiObjekat>().ToList());


                VratiSveZivotinjeSO cls = new VratiSveZivotinjePom(mock.Create<IRepozitorijum<IDomenskiObjekat>>());


                var expected = GetZivotinje();
                var actual = cls.VratiSveZivotinje();


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
                    Vrsta="Lav",
                    Staniste="Afrika",
                    Starost=123,
                    TipIshrane=TipIshrane.Mesojed,
                    Pol=Pol.Muski
                }
            };
        }



    }
}
