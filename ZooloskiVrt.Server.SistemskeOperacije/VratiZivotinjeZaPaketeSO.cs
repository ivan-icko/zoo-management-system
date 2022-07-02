using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;

namespace ZooloskiVrt.Server.SistemskeOperacije
{

    /// <summary>
    /// Klasa koja predstavlja sistemsku operaciju vracanja svih zivotinja za pakete iz baze
    /// </summary>
    public class VratiZivotinjeZaPaketeSO : OpstaSistemskaOperacija
    {
        /// <value>
        /// Privatni atribut zivotinja koji predstavlja instancu klase Zivotinja
        /// </value>
        public Zivotinja zivotinja;


        /// <summary>
        /// Parametarski konstruktor koji postavlja vrednost zivotinja na prosledjenu vrednost
        /// </summary>
        /// <param name="zivotinja">Prijava pp</param>
        public VratiZivotinjeZaPaketeSO(Zivotinja zivotinja)
        {
            this.zivotinja = zivotinja;
        }


        /// <summary>
        /// Besparametarski konstruktor koji nasladjuje konstruktor natklase OpstaSO
        /// </summary>
        public VratiZivotinjeZaPaketeSO() : base()
        {

        }


        /// <summary>
        /// Funkcija koja inicira izvrsavanje metode Izvrsi 
        /// </summary>
        /// <returns>Zivotinje za pakete iz baze podataka</returns>
        public List<Zivotinja> VratiSveZivotinjeZaPakete()
        {
            Izvrsi();
            return Zivotinje;
        }

        /// <value>
        /// Javni atribut Zivotinje koji predstavlja listu zivotinja iz baze
        /// </value>
        public List<Zivotinja> Zivotinje { get; set; } = new List<Zivotinja>();


        /// <summary>
        /// Metoda koja je nasledjena od klase OpstaSistemskaOperacija.<br/>
        /// U ovom slucaju uloga ove metode je da pozove sistemsku operaciju VratiSve(Zivotinja) <br/>
        /// </summary>
        /// <exception cref="Exception">U slucaju neuspelog vracanja zivotinja za prijave</exception>
        protected override void Izvrsi()
        {
            try
            {
                Zivotinje = repozitorijum.VratiSve(zivotinja).OfType<Zivotinja>().ToList();
            }
            catch (Exception ex)
            {
                Zivotinje = null;
                throw;
            }
        }
    }
}
