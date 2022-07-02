using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;

namespace ZooloskiVrt.Server.SistemskeOperacije
{
    /// <summary>
    /// Klasa koja predstavlja sistemsku operaciju vracanja svih prijava iz baze
    /// </summary>
    public class VratiSvePrijaveSO : OpstaSistemskaOperacija
    {
        /// <value>
        /// Privatni atribut pp koji predstavlja instancu klase Prijava
        /// </value>
        private Prijava pp;

        /// <value>
        /// Javni atribut Prijave koji predstavlja listu prijava iz baze
        /// </value>
        public List<Prijava> Prijave { get; set; } = new List<Prijava>();

        /// <summary>
        /// Besparametarski konstruktor koji nasladjuje konstruktor natklase OpstaSO
        /// </summary>
        public VratiSvePrijaveSO() : base()
        {

        }

     /// <summary>
     /// Parametarski konstruktor koji postavlja vrednost pp na prosledjenu vrednost
     /// </summary>
     /// <param name="pp">Prijava pp</param>
        public VratiSvePrijaveSO(Prijava pp)
        {
            this.pp = pp;
        }

        /// <summary>
        /// Funkcija koja inicira izvrsavanje metode Izvrsi 
        /// </summary>
        /// <returns>Prijave iz baze podataka</returns>
        public List<Prijava> VratiSvePrijave()
        {
            Izvrsi();
            return Prijave;
        }


        /// <summary>
        /// Metoda koja je nasledjena od klase OpstaSistemskaOperacija.<br/>
        /// U ovom slucaju uloga ove metode je da pozove sistemsku operaciju VratiSve(Prijava) <br/>
        /// </summary>
        /// <exception cref="Exception">U slucaju neuspelog vracanja prijava</exception>
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
