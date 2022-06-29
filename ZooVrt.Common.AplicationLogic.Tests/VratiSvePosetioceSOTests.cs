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
    public class VratiSvePosetiocePom : VratiSvePosetioceSO
    {
        public VratiSvePosetiocePom(IRepozitorijum<IDomenskiObjekat> mockRepository) : base()
        {
            this.repozitorijum = (IRepozitorijum<IDomenskiObjekat>)mockRepository;
        }
    }

    public class VratiSvePosetioceSOTests
    {
        [Fact]
        public void VratiSvePosetioce_Ok_Fact()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepozitorijum<IDomenskiObjekat>>()
                    .Setup(x => x.VratiSve(new Posetilac()))
                    .Returns(GetPosetioci().OfType<IDomenskiObjekat>().ToList());


                VratiSvePosetioceSO cls = new VratiSvePosetiocePom(mock.Create<IRepozitorijum<IDomenskiObjekat>>());


                var expected = GetPosetioci();
                var actual = cls.VratiSvePosetioce();


                Assert.True(actual != null);
                Assert.Equal(expected.Count, actual.Count);
                Assert.Equal(expected, actual);
            }
        }


        private List<Posetilac> GetPosetioci()
        {
            return new List<Posetilac>()
            {
                new Posetilac()
                {
                   Telefon="234"
                }
            };
        }



    }
}
