using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;

namespace ZooloskiVrt.Server.SistemskeOperacije
{
    public class VratiSvePrijaveSO : OpstaSistemskaOperacija
    {
        private Prijava pp;
        public List<Prijava> Prijave { get; set; } = new List<Prijava>();

        public VratiSvePrijaveSO() : base()
        {

        }

        public VratiSvePrijaveSO(Prijava pp)
        {
            this.pp = pp;
        }

        public List<Prijava> VratiSvePrijave()
        {
            Izvrsi();
            return Prijave;
        }


        protected override void Izvrsi()
        {
            try
            {
                Prijave = repozitorijum.VratiSve(new Prijava()).OfType<Prijava>().ToList();
            }
            catch (Exception ex)
            {
                Prijave = null;
                throw;
            }
        }
    }
}
