using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;

namespace ZooloskiVrt.Server.SistemskeOperacije
{
    /// <summary>
    /// Klasa koja predstavlja sistemsku operaciju pronalazenja zaposlenog
    /// </summary>
    public class PronadjiZaposlenogSO : OpstaSistemskaOperacija
    {



        /// <value>
        /// Javni atribut Zaposleni koji sadrzi atribute po kojima se traze zadati zaposleni 
        /// </value>
        public Zaposleni Zaposleni { get; set; }

        /// <value>
        /// Javni atribut ZaposleniList koji predstavlja listu zaposlenih koje je potrebno vratiti iz baze
        /// </value>
        public List<Zaposleni> ZaposleniList = new List<Zaposleni>();

        /// <summary>
        /// Parametarski konstruktor klase PronadjiZaposlenogSO, koji inicijalizuje zaposlenog za pronalazenje
        /// </summary>
        /// <param name="p">Paket za pronalazenje</param>
        public PronadjiZaposlenogSO(Zaposleni z)
        {
            Zaposleni = z;

        }


        /// <summary>
        /// Besparametarski konstruktor klase PronadjiZaposlenogSO  , <br/>
        /// koji nasledjije besparametarski konstruktor natklase OpstaSistemskaOperacija
        /// </summary>
        public PronadjiZaposlenogSO() : base()
        {

        }
        /// <summary>
        /// Javna metoda koja poziva metodu Izvrsi koja puni atribut ZaposleniList
        /// </summary>
        /// <returns>Zaposleni iz baze</returns>
        public List<Zaposleni> VratiZaposlenog()
        {
            Izvrsi();
            return ZaposleniList;
        }


        /// <summary>
        /// Metoda koja je nasledjena od klase OpstaSistemskaOperacija.<br/>
        /// U ovom slucaju uloga ove metode je da pozove sistemsku operaciju Pretrazi(Zaposleni) <br/>
        /// </summary>
        /// <exception cref="Exception">U slucaju neuspelog pretrazivanja</exception>
        protected override void Izvrsi()
        {
            try
            {
                ZaposleniList = (repozitorijum.Pretrazi(Zaposleni).OfType<Zaposleni>().ToList());
            }
            catch (Exception ex)
            {
                Zaposleni = null;
                throw;
            }
        }
    }
}
