using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;

namespace ZooloskiVrt.Server.SistemskeOperacije
{
    /// <summary>
    /// Klasa koja predstavlja sistemsku operaciju brisanje zivotinje
    /// </summary>
    public class ObrisiZivotinjuSO : OpstaSistemskaOperacija
    {
        /// <value>
        /// Javni atribut Zivotinja koji sadrzi id zivotinje koju je potrebno obrisati
        /// </value>
        public Zivotinja Zivotinja { get; set; }
        /// <value>
        /// Boolean vrednost koja je je true kada je operacija brisanja zivotinje uspesno izvrsena, <br/>
        /// ili false kada nije
        /// </value>
        public bool Signal { get; set; } = true;

        /// <summary>
        /// Parametarski konstruktor klase ObrisiZivotinjuSO, koji inicijalizuje zivotinju za brisanje
        /// </summary>
        /// <param name="z">Zivotinja za brisanje</param>
        public ObrisiZivotinjuSO(Zivotinja z)
        {
            Zivotinja = z;
        }


        /// <summary>
        /// Besparametarski konstruktor klase ObrisiZivotinjuSO  , <br/>
        /// koji nasledjije besparametarski konstruktor natklase OpstaSistemskaOperacija
        /// </summary>
        public ObrisiZivotinjuSO():base()
        {

        }
        /// <summary>
        /// Javna metoda koja ima ulogu da pozove protected metodu Izvrsi
        /// </summary>
        public void Test()
        {
            Izvrsi();
        }

        /// <summary>
        /// Metoda koja je nasledjena od klase OpstaSistemskaOperacija.<br/>
        /// U ovom slucaju uloga ove metode je da pozove sistemsku operaciju Obrisi(Zivotinja) <br/>
        /// </summary>
        /// <exception cref="Exception">U slucaju neuspelog brisanja zivotinje</exception>
        protected override void Izvrsi()
        {
            try
            {
                repozitorijum.Obrisi(Zivotinja);
            }
            catch (Exception ex)
            {
                Signal = false;
                throw;
            }
        }
    }
}
