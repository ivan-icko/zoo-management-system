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

    public class PronadjiZaposlenogSOTests
    {
        [Fact]
        public void PronadjiZaposlenog_Ok_Fact()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Zaposleni z = new Zaposleni() { Sifra = "SId" };
                mock.Mock<IRepozitorijum<IDomenskiObjekat>>()
                    .Setup(x => x.Pretrazi(z))
                    .Returns(GetZaposleni().OfType<IDomenskiObjekat>().ToList());


                PronadjiZaposlenogSO cls = new PronadjiZaposlenogPom(mock.Create<IRepozitorijum<IDomenskiObjekat>>());


                var expected = GetZaposleni();
                cls.Zaposleni = z;
                var actual = cls.VratiZaposlenog();


                Assert.True(actual != null);
                
                Assert.Equal(expected, actual);
            }
        }


        private List<Zaposleni> GetZaposleni()
        {

            return new List<Zaposleni>()
            {
                new Zaposleni()
                {
                    Sifra="isdf"
                }
            };
            
        }



    }
}
