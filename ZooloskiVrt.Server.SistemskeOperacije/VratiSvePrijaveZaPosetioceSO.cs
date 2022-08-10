using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;

namespace ZooloskiVrt.Server.SistemskeOperacije
{
    /// <summary>
    /// Klasa koja predstavlja sistemsku operaciju vracanja svih prijava za posetioce iz baze
    /// </summary>
    public class VratiSvePrijaveZaPosetioceSO : OpstaSistemskaOperacija
    {
        /// <value>
        /// Privatni atribut pp koji predstavlja instancu klase PosetilacPrijava
        /// </value>
        public PosetilacPrijava pp;


        /// <summary>
        /// Besparametarski konstruktor koji nasladjuje konstruktor natklase OpstaSO
        /// </summary>
        public VratiSvePrijaveZaPosetioceSO() : base()
        {

        }

        /// <summary>
        /// Parametarski konstruktor koji postavlja vrednost pp na prosledjenu vrednost
        /// </summary>
        /// <param name="pp">Posetilac prijava pp</param>
        public VratiSvePrijaveZaPosetioceSO(PosetilacPrijava pp)
        {
            this.pp = pp;
        }

        /// <summary>
        /// Funkcija koja inicira izvrsavanje metode Izvrsi 
        /// </summary>
        /// <returns>PosetilacPrijava iz baze podataka</returns>
        public List<PosetilacPrijava> VratiPosetiocePrijava()
        {
            Izvrsi();
            return Prijave;
        }

        /// <value>
        /// Javni atribut PosetilacPrijava koji predstavlja listu prijava za posetioca iz baze
        /// </value>
        public List<PosetilacPrijava> Prijave { get; set; } = new List<PosetilacPrijava>();



        /// <summary>
        /// Metoda koja je nasledjena od klase OpstaSistemskaOperacija.<br/>
        /// U ovom slucaju uloga ove metode je da pozove sistemsku operaciju VratiSve(PosetilacPrijava) <br/>
        /// </summary>
        /// <exception cref="Exception">U slucaju neuspelog vracanja prijava za posetioce</exception>
        protected override void Izvrsi()
        {
            try
            {
                Prijave = repozitorijum.VratiSve(pp).OfType<PosetilacPrijava>().ToList();
            }
            catch (Exception ex)
            {
                Prijave = null;
                throw;
            }
        }
    }
}
