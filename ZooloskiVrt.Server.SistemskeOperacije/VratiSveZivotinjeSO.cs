using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;
using ZooloskiVrt.Server.Repozitorujum;

namespace ZooloskiVrt.Server.SistemskeOperacije
{

    /// <summary>
    /// Klasa koja predstavlja sistemsku operaciju vracanja svih zivotinja iz baze
    /// </summary>
    public class VratiSveZivotinjeSO : OpstaSistemskaOperacija
    {
        /// <value>
        /// Javni atribut Zivotinje koji predstavlja listu zivotinja iz baze
        /// </value>
        public List<Zivotinja> Zivotinje { get; set; } = new List<Zivotinja>();


        /// <summary>
        /// Funkcija koja inicira izvrsavanje metode Izvrsi 
        /// </summary>
        /// <returns>ZIvotinje iz baze podataka</returns>
        public List<Zivotinja> VratiSveZivotinje() { 
                Izvrsi();
            return Zivotinje;
        }


        /// <summary>
        /// Metoda koja je nasledjena od klase OpstaSistemskaOperacija.<br/>
        /// U ovom slucaju uloga ove metode je da pozove sistemsku operaciju VratiSve(Zivotinje) <br/>
        /// </summary>
        /// <exception cref="Exception">U slucaju neuspelog vracanja zivotinja</exception>
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
