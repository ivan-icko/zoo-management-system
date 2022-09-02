using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;

namespace ZooloskiVrt.Server.SistemskeOperacije
{

    /// <summary>
    /// Klasa koja predstavlja sistemsku operaciju cuvanja paketa
    /// </summary>
    public class SacuvajPaketSO : OpstaSistemskaOperacija
    {
        /// <value>
        /// Javni atribut p koji sadrzi atribute koje treba sacuvati u bazi 
        /// </value>
        public Paket p=new Paket();

        /// <value>
        /// Boolean vrednost koja moze biti true, ako je cuvanje paketa uspesno, <br/> ili false ako nije
        /// </value>
        public bool Signal { get; set; } = true;

        /// <summary>
        /// Parametarski konstruktor klase SacuvajPaketeSO, koji inicijalizuje pakete za cuvanje
        /// </summary>
        /// <param name="p">Paket koji je potrebno sacuvati</param>
        public SacuvajPaketSO(Paket p)
        {
            this.p = p;
        }

        /// <summary>
        /// Besparametarski konstruktor klase SacuvajPaketeSO  , <br/>
        /// koji nasledjije besparametarski konstruktor natklase OpstaSistemskaOperacija
        /// </summary>
        public SacuvajPaketSO():base()
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
        /// U ovom slucaju uloga ove metode je da pozove sistemsku operaciju Sacuvaj(Paket) <br/>
        /// </summary>
        /// <exception cref="Exception">U slucaju neuspelog cuvanja</exception>
        protected override void Izvrsi()
        {
            try
            {
                
                repozitorijum.Sacuvaj(p);
                int maxId = repozitorijum.VratiNajveciId(p);
                if (p.ListaIdjevaZivotinja != null && p.ListaIdjevaZivotinja.Count > 0)
                {
                    foreach (int id in p.ListaIdjevaZivotinja)
                    {
                        repozitorijum.Sacuvaj(new PaketZivotinja { IdPaketa = maxId, IdZivotinje = id });
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
