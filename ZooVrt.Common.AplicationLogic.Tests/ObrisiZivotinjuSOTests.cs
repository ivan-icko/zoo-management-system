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
    public class ObrisiZivotinjuPom : ObrisiZivotinjuSO
    {
        public ObrisiZivotinjuPom(IRepozitorijum<IDomenskiObjekat> mockRepository) : base()
        {
            this.repozitorijum = (IRepozitorijum<IDomenskiObjekat>)mockRepository;
        }
    }

    public class ObrisiZIvotinjuSOTests
    {
        [Fact]
        public void ObrisiZivotinju_Ok_Fact()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Zivotinja z = new Zivotinja() { Vrsta = "Lav" };
                mock.Mock<IRepozitorijum<IDomenskiObjekat>>()
                    .Setup(x => x.Obrisi(z));

                ObrisiZivotinjuSO cls = new ObrisiZivotinjuPom(mock.Create<IRepozitorijum<IDomenskiObjekat>>());

                cls.Zivotinja = z;
                cls.Test();

                mock.Mock<IRepozitorijum<IDomenskiObjekat>>()
                   .Verify(x => x.Obrisi(z), Times.Exactly(1));
            }
        }



    }
}
