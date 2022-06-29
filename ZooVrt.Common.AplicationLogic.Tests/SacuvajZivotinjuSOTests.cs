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
    public class SacuvajZivotinjuPom : SacuvajZivotinjuSO
    {
        public SacuvajZivotinjuPom(IRepozitorijum<IDomenskiObjekat> mockRepository) : base()
        {
            this.repozitorijum = (IRepozitorijum<IDomenskiObjekat>)mockRepository;
        }
    }

    public class SacuvajZivotinjuSOTests
    {
        [Fact]
        public void SacuvajZivotinju_Ok_Fact()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Zivotinja z = new Zivotinja() { Vrsta = "Lav" };
                mock.Mock<IRepozitorijum<IDomenskiObjekat>>()
                    .Setup(x => x.Sacuvaj(z));

                SacuvajZivotinjuSO cls = new SacuvajZivotinjuPom(mock.Create<IRepozitorijum<IDomenskiObjekat>>());

                cls.zivotinja = z;
                cls.Test();

                mock.Mock<IRepozitorijum<IDomenskiObjekat>>()
                   .Verify(x => x.Sacuvaj(z), Times.Exactly(1));
            }
        }



    }
}
