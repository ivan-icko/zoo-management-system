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
    public class AzurirajZivotinjuPom : AzurirajZivotinjuSO
    {
        public AzurirajZivotinjuPom(IRepozitorijum<IDomenskiObjekat> mockRepository) : base()
        {
            this.repozitorijum = (IRepozitorijum<IDomenskiObjekat>)mockRepository;
        }
    }

    public class AzurirajZivotinjuSOTests
    {
        [Fact]
        public void AzurirajPaket_Ok_Fact()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Zivotinja z = new Zivotinja() { Vrsta = "Lav" };
                mock.Mock<IRepozitorijum<IDomenskiObjekat>>()
                    .Setup(x => x.Azuriraj(z));


                AzurirajZivotinjuSO cls = new AzurirajZivotinjuPom(mock.Create<IRepozitorijum<IDomenskiObjekat>>());

                cls.Z = z;
                cls.Test();

                mock.Mock<IRepozitorijum<IDomenskiObjekat>>()
                   .Verify(x => x.Azuriraj(z), Times.Exactly(1));
            }
        }



    }
}
