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
    public class SacuvajPrijavuPom : SacuvajPrijavuSO
    {
        public SacuvajPrijavuPom(IRepozitorijum<IDomenskiObjekat> mockRepository) : base()
        {
            this.repozitorijum = (IRepozitorijum<IDomenskiObjekat>)mockRepository;
        }
    }

    public class SacuvajPrijavuSOTests
    {
        
        public void SacuvajPrijavu_Ok_Fact()
        {
            using (var mock = AutoMock.GetLoose())
            {
                Prijava p = new Prijava() { BrojOsoba = 3 };
                mock.Mock<IRepozitorijum<IDomenskiObjekat>>()
                    .Setup(x => x.Sacuvaj(p));

                SacuvajPrijavuSO cls = new SacuvajPrijavuPom(mock.Create<IRepozitorijum<IDomenskiObjekat>>());
                cls.prijava = p;
                cls.Test();

                mock.Mock<IRepozitorijum<IDomenskiObjekat>>()
                   .Verify(x => x.Sacuvaj(p), Times.Exactly(1));
            }
        }



    }
}
