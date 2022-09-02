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
    public class VratiSvePosetioceZaPaket : OpstaSistemskaOperacija
    {
        /// <summary>
        /// Klasa koja predstavlja sistemsku operaciju vracanja svih posetioca za odredjeni paket
        /// </summary>
        public VratiSvePosetioceZaPaket(Paket paket)
        {
            Paket = paket;
            Posetilac.Uslov = paket.Uslov;
            Posetilac.JoinUslov = paket.JoinUslov;
        }

        /// <value>
        /// Javni atribut Posetioci koji predstavlja listu posetilaca iz baze
        /// </value>
        public List<Posetilac> Posetioci { get; set; }
        /// <value>
        /// Javni atribut Pkaet koji predstavlja paket sa zivotinjama
        /// </value>
        public Paket Paket { get; }
        /// <value>
        /// Javni atribut Posetilac koji predstavlja posetioca vrta
        /// </value>
        public Posetilac Posetilac { get; set; } = new Posetilac();


        /// <summary>
        /// Metoda koja je nasledjena od klase OpstaSistemskaOperacija.<br/>
        /// U ovom slucaju uloga ove metode je da pozove sistemsku operaciju VratiSve(Posetilac) <br/>
        /// </summary>
        /// <exception cref="Exception">U slucaju neuspelog vracanja posetilaca</exception>
        protected override void Izvrsi()
        {
            try
            {
                Posetioci = repozitorijum.VratiSve(Posetilac).OfType<Posetilac>().Distinct().ToList();
                if (Posetioci.Count == 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Posetioci = null;
                throw;
            }
        }
    }
}
