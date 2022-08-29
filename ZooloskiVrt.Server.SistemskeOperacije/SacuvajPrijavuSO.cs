using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;

namespace ZooloskiVrt.Server.SistemskeOperacije
{

    /// <summary>
    /// Klasa koja predstavlja sistemsku operaciju cuvanja Prijave
    /// </summary>
    public class SacuvajPrijavuSO : OpstaSistemskaOperacija
    {
        /// <value>
        /// Javni atribut prijava koji sadrzi atribute koje treba sacuvati u bazi 
        /// </value>
        public Prijava prijava;

        public Paket paket;

        /// <value>
        /// Boolean vrednost koja moze biti true, ako je cuvanje prijave uspesno, <br/> ili false ako nije
        /// </value>
        public bool Signal { get; set; } = true;

        /// <summary>
        /// Parametarski konstruktor klase SacuvajPrijavuSO, koji inicijalizuje prijavu za cuvanje
        /// </summary>
        /// <param name="prijava">Prijava koju je potrebno sacuvati</param>
        public SacuvajPrijavuSO(Prijava prijava)
        {
            this.prijava = prijava;
        }

        /// <summary>
        /// Besparametarski konstruktor klase SacuvajPrijavuSO  , <br/>
        /// koji nasledjije besparametarski konstruktor natklase OpstaSistemskaOperacija
        /// </summary>
        public SacuvajPrijavuSO():base()
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
        /// U ovom slucaju uloga ove metode je da pozove sistemsku operaciju Sacuvaj(Prijava) <br/>
        /// </summary>
        /// <exception cref="Exception">U slucaju neuspelog cuvanja</exception>
        protected override void Izvrsi()
        {
            try
            {
                Paket paket = new Paket();
                paket.Uslov = $"IdPaketa={prijava.IdPaketa}";
                var paketi = repozitorijum.Pretrazi(paket);
                paket=paketi[0] as Paket;
                paket.Uslov = $"IdPaketa={prijava.IdPaketa}";
                if (prijava.BrojOsoba > paket.BrojSlobodnihMesta)
                {
                    throw new Exception();
                }
                else
                {
                    paket.BrojSlobodnihMesta -= prijava.BrojOsoba;
                    repozitorijum.Azuriraj(paket);
                }


                repozitorijum.Sacuvaj(prijava);
            }
            catch (Exception ex)
            {
                Signal = false;
                throw;
            }
        }
    }
}
