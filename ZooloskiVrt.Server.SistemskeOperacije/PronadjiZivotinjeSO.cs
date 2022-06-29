using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;

namespace ZooloskiVrt.Server.SistemskeOperacije
{
    public class PronadjiZivotinjeSO : OpstaSistemskaOperacija
    {
        public List<Zivotinja> Zivotinje { get; set; } = new List<Zivotinja>();
        public Zivotinja Z { get; set; }
        public PronadjiZivotinjeSO(Zivotinja z)
        {
            Z = z;
        }
        public PronadjiZivotinjeSO():base()
        {

        }

        public List<Zivotinja> VratiZivotinje()
        {
            Izvrsi();
            return Zivotinje;
        }


        protected override void Izvrsi()
        {
            try
            {
                Zivotinje = repozitorijum.Pretrazi(new Zivotinja()).OfType<Zivotinja>().ToList();
            }
            catch (Exception ex)
            {
                Zivotinje = null;
                throw;
            }

        }
    }
}
