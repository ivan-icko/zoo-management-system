using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;

namespace ZooloskiVrt.Server.SistemskeOperacije
{

    /// <summary>
    /// Klasa koja predstavlja sistemsku operaciju vracanja svih paketa iz baze
    /// </summary>
    public class VratiSvePaketeSO : OpstaSistemskaOperacija   
    {
        /// <value>
        /// Javni atribut Paketi koji predstavlja listu paketa iz baze
        /// </value>
        public List<Paket> Paketi { get; set; } = new List<Paket>();

        /// <summary>
        /// Funkcija koja inicira izvrsavanje metode Izvrsi
        /// </summary>
        /// <returns>Paketi iz baze podataka</returns>
        public List<Paket> VratiSvePakete()
        {
            Izvrsi();
            return Paketi;
        }


        /// <summary>
        /// Metoda koja je nasledjena od klase OpstaSistemskaOperacija.<br/>
        /// U ovom slucaju uloga ove metode je da pozove sistemsku operaciju VratiSve(Paket) <br/>
        /// </summary>
        /// <exception cref="Exception">U slucaju neuspelog vracanja paketa</exception>
        protected override void Izvrsi()
        {
            try
            {
                Paketi = repozitorijum.VratiSve(new Paket()).OfType<Paket>().ToList();

            }
            catch (Exception ex) 
            {
                Paketi = null;
                throw;
            }
        }
    }
}
