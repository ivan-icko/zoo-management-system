using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;

namespace ZooloskiVrt.Server.SistemskeOperacije
{
    /// <summary>
    /// Klasa koja predstavlja sistemsku operaciju cuvanja Zivotinje
    /// </summary>
    public class SacuvajZivotinjuSO : OpstaSistemskaOperacija
    {
        /// <value>
        /// Javni atribut zivotinja koji sadrzi atribute koje treba sacuvati u bazi 
        /// </value>
        public Zivotinja zivotinja;

        /// <value>
        /// Boolean vrednost koja moze biti true, ako je cuvanje zivotinje uspesno, <br/> ili false ako nije
        /// </value>
        public bool Signal { get; set; } = true;

        /// <summary>
        /// Parametarski konstruktor klase SacuvajZivotinjuSO, koji inicijalizuje zivotinju za cuvanje
        /// </summary>
        /// <param name="z">Zivotinja z</param>
        public SacuvajZivotinjuSO(Zivotinja z)
        {
            zivotinja = z;
        }
        /// <summary>
        /// Besparametarski konstruktor klase SacuvajZivotinjuSO  , <br/>
        /// koji nasledjije besparametarski konstruktor natklase OpstaSistemskaOperacija
        /// </summary>
        public SacuvajZivotinjuSO():base()
        {

        }

        /// <summary>
        /// Javna metoda koja poziva metodu Izvrsi koja postavlja vrednost atributu signal
        /// </summary>
        public void Test()
        {
            Izvrsi();
        }


        /// <summary>
        /// Metoda koja je nasledjena od klase OpstaSistemskaOperacija.<br/>
        /// U ovom slucaju uloga ove metode je da pozove sistemsku operaciju Sacuvaj(Zivotinja) <br/>
        /// </summary>
        /// <exception cref="Exception">U slucaju neuspelog cuvanja</exception>
        protected override void Izvrsi()
        {
            try
            {
                repozitorijum.Sacuvaj(zivotinja);
            }
            catch (Exception ex)
            {
                Signal = false;
                throw;
            }
        }
    }
}
