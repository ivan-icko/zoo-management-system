using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;

namespace ZooloskiVrt.Server.SistemskeOperacije
{
    public class PronadjiZaposlenogSO : OpstaSistemskaOperacija
    {
        
        
        
        
        public Zaposleni Zaposleni { get; set; }
        public List<Zaposleni> ZaposleniList = new List<Zaposleni>();
        public PronadjiZaposlenogSO(Zaposleni z)
        {
            Zaposleni = z;

        }
        public PronadjiZaposlenogSO() : base()
        {

        }

        public List<Zaposleni> VratiZaposlenog()
        {
            Izvrsi();
            return ZaposleniList;
        }

        protected override void Izvrsi()
        {
            try
            {
                ZaposleniList = (repozitorijum.Pretrazi(new Zaposleni()).OfType<Zaposleni>().ToList());
            }
            catch (Exception ex)
            {
                Zaposleni = null;
                throw;
            }
        }
    }
}
