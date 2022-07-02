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
    
    public class AzurirajPaketPom : AzurirajPaketSO
    {
       
        public AzurirajPaketPom(IRepozitorijum<IDomenskiObjekat> mockRepository) : base()
        {
            this.repozitorijum = (IRepozitorijum<IDomenskiObjekat>)mockRepository;
        }
    }
    
    public class AzurirajPaketSOTests
    {
        [Fact]
        public void AzurirajPaket_Ok_Fact()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Paket p = new Paket() { NazivPaketa = "Paket1" };
                mock.Mock<IRepozitorijum<IDomenskiObjekat>>()
                    .Setup(x => x.Azuriraj(p));


                AzurirajPaketSO cls = new AzurirajPaketPom(mock.Create<IRepozitorijum<IDomenskiObjekat>>());

                cls.paket = p;
                cls.Test();

                mock.Mock<IRepozitorijum<IDomenskiObjekat>>()
                   .Verify(x => x.Azuriraj(p), Times.Exactly(1));
            }
        }



    }
}
