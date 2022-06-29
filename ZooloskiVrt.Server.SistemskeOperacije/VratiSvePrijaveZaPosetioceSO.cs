using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;

namespace ZooloskiVrt.Server.SistemskeOperacije
{
    public class VratiSvePrijaveZaPosetioceSO : OpstaSistemskaOperacija
    {
        public PosetilacPrijava pp;

        public VratiSvePrijaveZaPosetioceSO() : base()
        {

        }

        public VratiSvePrijaveZaPosetioceSO(PosetilacPrijava pp)
        {
            this.pp = pp;
        }

        public List<PosetilacPrijava> VratiPosetiocePrijava()
        {
            Izvrsi();
            return Prijave;
        }

        public List<PosetilacPrijava> Prijave { get; set; } = new List<PosetilacPrijava>();

        protected override void Izvrsi()
        {
            try
            {
                Prijave = repozitorijum.VratiSve(new PosetilacPrijava()).OfType<PosetilacPrijava>().ToList();
            }
            catch (Exception ex)
            {
                Prijave = null;
                throw;
            }
        }
    }
}
