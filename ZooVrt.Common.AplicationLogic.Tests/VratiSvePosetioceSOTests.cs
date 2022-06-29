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


namespace ZooVrt.Common.AplicationLogic.Tests
{
    public class VratiSvePosetioceSOPom : VratiSvePosetioceSO
    {
        public VratiSvePosetioceSOPom(IRepozitorijum<IDomenskiObjekat> mockRepository) : base()
        {
            this.repozitorijum = (IRepozitorijum<IDomenskiObjekat>)mockRepository;
        }
    }


    public class VratiSvePosetioceSOTests
    {
        [Fact]
        public void VratiSveZivotinje_Ok_Fact()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IRepozitorijum<IDomenskiObjekat>>()
                    .Setup(x => x.VratiSve(new Posetilac()))
                    .Returns(GetZivotinje().OfType<IDomenskiObjekat>().ToList());


                VratiSvePosetioceSO cls = new VratiSvePosetioceSOPom(mock.Create<IRepozitorijum<IDomenskiObjekat>>());


                var expected = GetZivotinje();
                var actual = cls.VratiSvePosetioce();


                Assert.True(actual != null);
                Assert.Equal(expected.Count, actual.Count);
                Assert.Equal(expected, actual);
            }
        }


        private List<Posetilac> GetZivotinje()
        {
            return new List<Posetilac>()
            {
                new Posetilac()
                {
                  Email="icko@gmail.com"
                }
            };
        }



    }
}
