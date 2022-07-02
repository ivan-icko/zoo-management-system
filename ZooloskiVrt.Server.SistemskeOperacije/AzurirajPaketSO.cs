using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;

namespace ZooloskiVrt.Server.SistemskeOperacije
{

    /// <summary>
    /// Klasa koja predstavlja sistemsku operaciju azuriranja paketa
    /// </summary>
    public class AzurirajPaketSO : OpstaSistemskaOperacija
    {
        /// <value>
        /// Instanca klase paket kojoj se dodeljuju atributi za azuriranje
        /// </value>
        public Paket paket;

        /// <value>
        /// Boolean vrednost koja moze biti true, ako je azuriranje uspesno, <br/>
        /// ili false ako nije
        /// </value>
        public bool Signal { get; set; } = true;

        /// <summary>
        /// Parametasrski konstruktor klase Azuriraj paket
        /// </summary>
        /// <param name="paket">Paket koji sadrzi informacija za azuriranje</param>
        public AzurirajPaketSO(Paket paket)
        {
            this.paket = paket;
        }
        /// <summary>
        /// Besparametarski konstruktor klase Azuriraj paket, <br/>
        /// koji nasledjije besparametarski konstruktor natklase OpstaSistemskaOperacija
        /// </summary>
        public AzurirajPaketSO() : base()
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
        /// U ovom slucaju uloga ove metode je da pozove sistemsku operaciju Azuriraj(Paket) <br/>
        /// Nakon azuriranja paketa brise se red u tabeli PaketZivotinja, kako bi se <br/>
        /// potencijalno novi redovi dodali i pri tome ocuvala struktura baze
        /// </summary>
        /// <exception cref="Exception">U slucaju neuspelog azuriranja paketa</exception>
        protected override void Izvrsi()
        {

            try
            {

                repozitorijum.Azuriraj(paket);
                try
                {
                    repozitorijum.Obrisi(new PaketZivotinja() { Uslov = $"IdPaketa={paket.IdPaketa}" });
                }
                catch (Exception ex)
                {
                }
                if (paket.ListaIdjevaZivotinja != null && paket.ListaIdjevaZivotinja.Count > 0)
                {
                    foreach (int id in paket.ListaIdjevaZivotinja)
                    {
                        repozitorijum.Sacuvaj(new PaketZivotinja { IdPaketa = paket.IdPaketa, IdZivotinje = id });
                    }
                }
            }
            catch (Exception ex)
            {
                Signal = false;
                throw;
            }
        }
    }
}
