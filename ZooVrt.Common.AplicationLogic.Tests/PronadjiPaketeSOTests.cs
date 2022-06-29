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
    public class PronadjiPaketePom : PronadjiPaketeSO
    {
        public PronadjiPaketePom(IRepozitorijum<IDomenskiObjekat> mockRepository) : base()
        {
            this.repozitorijum = (IRepozitorijum<IDomenskiObjekat>)mockRepository;
        }
    }

    public class PronadjiPaketeSOTests
    {
        [Fact]
        public void PronadjiPakete_Ok_Fact()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepozitorijum<IDomenskiObjekat>>()
                    .Setup(x => x.Pretrazi(new Paket()))
                    .Returns(GetZaposleni().OfType<IDomenskiObjekat>().ToList());


                PronadjiPaketeSO cls = new PronadjiPaketePom(mock.Create<IRepozitorijum<IDomenskiObjekat>>());


                var expected = GetZaposleni();
                var actual = cls.VratiPakete();


                Assert.True(actual != null);

                Assert.Equal(expected, actual);
            }
        }


        private List<Paket> GetZaposleni()
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
