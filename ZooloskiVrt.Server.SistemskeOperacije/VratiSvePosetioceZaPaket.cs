using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;

namespace ZooloskiVrt.Server.SistemskeOperacije
{
    public class VratiSvePosetioceZaPaket : OpstaSistemskaOperacija
    {
        public VratiSvePosetioceZaPaket(Paket paket)
        {
            Paket = paket;
            Posetilac.Uslov = paket.Uslov;
            Posetilac.JoinUslov = paket.JoinUslov;
        }

        public List<Posetilac> Posetioci { get; set; }
        public Paket Paket { get; }
        public Posetilac Posetilac { get; set; } = new Posetilac();

        protected override void Izvrsi()
        {
            try
            {
                Posetioci = repozitorijum.VratiSve(Posetilac).OfType<Posetilac>().Distinct().ToList();
            }
            catch (Exception ex)
            {
                Posetioci = null;
                throw;
            }
        }
    }
}
