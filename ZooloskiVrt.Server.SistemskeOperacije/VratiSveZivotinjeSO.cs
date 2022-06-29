using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;
using ZooloskiVrt.Server.Repozitorujum;

namespace ZooloskiVrt.Server.SistemskeOperacije
{
    public class VratiSveZivotinjeSO : OpstaSistemskaOperacija
    {
        /*public VratiSveZivotinjeSO():base()
        {
            
        }

        public VratiSveZivotinjeSO(IRepozitorijum<IDomenskiObjekat> repozitorijum ):base(repozitorijum)
        {
            
        }*/

        public List<Zivotinja> Zivotinje { get; set; } = new List<Zivotinja>();

        public  List<Zivotinja> VratiSveZivotinje()
        {

            try
            {
                Zivotinje = repozitorijum.VratiSve(new Zivotinja()).OfType<Zivotinja>().ToList();
                //Izvrsi();
            }
            catch (Exception ex)
            {
                Zivotinje = null;
                throw;
            }
            return Zivotinje;
        }

       

        protected override void Izvrsi()
        {
            try
            {
                Zivotinje = repozitorijum.VratiSve(new Zivotinja()).OfType<Zivotinja>().ToList();
            }
            catch (Exception ex)
            {
                Zivotinje = null;
                throw;
            }
        }
    }
}
