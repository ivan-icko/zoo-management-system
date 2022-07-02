using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;

namespace ZooloskiVrt.Server.SistemskeOperacije
{
    /// <summary>
    /// Klasa koja predstavlja sistemsku operaciju vracanja svih posetioca iz baze
    /// </summary>
    public class VratiSvePosetioceSO : OpstaSistemskaOperacija
    {
        /// <value>
        /// Javni atribut Posetioci koji predstavlja listu posetilaca iz baze
        /// </value>
        public List<Posetilac> Posetioci { get; set; } = new List<Posetilac>();

        /// <value>
        /// Javni atribut p koji predstavlja klasu Posetilac
        /// </value>
        public Posetilac p;

        /// <summary>
        /// Funkcija koja inicira izvrsavanje metode Izvrsi 
        /// </summary>
        /// <returns>Posetioci iz baze podataka</returns>
        public List<Posetilac> VratiSvePosetioce()
        {
            Izvrsi();
            return Posetioci;
        }

        /// <summary>
        /// Besparametarski konstruktor koji nasladjuje konstruktor natklase OpstaSO
        /// </summary>
        public VratiSvePosetioceSO() : base()
        {

        }


        /// <summary>
        /// Metoda koja je nasledjena od klase OpstaSistemskaOperacija.<br/>
        /// U ovom slucaju uloga ove metode je da pozove sistemsku operaciju VratiSve(Posetilac) <br/>
        /// </summary>
        /// <exception cref="Exception">U slucaju neuspelog vracanja posetilaca</exception>
        protected override void Izvrsi()
        {
            try
            {
                Posetioci = repozitorijum.VratiSve(new Posetilac()).OfType<Posetilac>().ToList();
            }
            catch (Exception ex)
            {
               Posetioci = null;
                throw;
            }
        }
    }
}
