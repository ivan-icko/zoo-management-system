using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;

namespace ZooloskiVrt.Server.SistemskeOperacije
{
    /// <summary>
    /// Klasa koja predstavlja sistemsku operaciju azuriranja zivotinje
    /// </summary>
    public class AzurirajZivotinjuSO : OpstaSistemskaOperacija
    {
        /// <value>
        /// Javni atribut koji predstavlja zivotinju koju je potrebno obrisati
        /// </value>
        public Zivotinja Z { get; set; }

        /// <value>
        /// Boolean vrednost koja moze biti true, ako je azuriranje uspesno, <br/>
        /// ili false ako nije
        /// </value>
        public bool Signal { get; set; } = true;

        /// <summary>
        /// Parametarski konstruktor koji postavlja vrednost atributa Z na odredjenu zivotinju
        /// </summary>
        /// <param name="z">Zivotinja koju je potrebno obrisati</param>
        public AzurirajZivotinjuSO(Zivotinja z)
        {
            Z = z;
        }
        /// <summary>
        /// Besparametarski konstruktor klase AzurirajZivotinju  , <br/>
        /// koji nasledjije besparametarski konstruktor natklase OpstaSistemskaOperacija
        /// </summary>
        public AzurirajZivotinjuSO():base()
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
        /// U ovom slucaju uloga ove metode je da pozove sistemsku operaciju Azuriraj(Zivotinja) <br/>
        /// </summary>
        /// <exception cref="Exception">U slucaju neuspelog azuriranja zivotinje</exception>
        protected override void Izvrsi()
        {
            try
            {
                repozitorijum.Azuriraj(Z);
            }
            catch (Exception ex)
            {
                Signal = false;
                throw;
            }
        }
    }
}
