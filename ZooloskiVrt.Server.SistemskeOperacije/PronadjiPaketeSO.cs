using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;

namespace ZooloskiVrt.Server.SistemskeOperacije
{

    /// <summary>
    /// Klasa koja predstavlja sistemsku operaciju pronalazenja paketa
    /// </summary>
    public class PronadjiPaketeSO : OpstaSistemskaOperacija
    {
        /// <value>
        /// Javni atribut Paketi koji predstavlja listu paketa koje je potrebno vratiti iz baze
        /// </value>
        public List<Paket> Paketi { get; set; } = new List<Paket>();
        /// <value>
        /// Javni atribut Paket koji sadrzi atribute po kojima se traze zadati paketi 
        /// </value>
        public Paket P { get; set; }

        /// <summary>
        /// Parametarski konstruktor klase PronadiPaketeSO, koji inicijalizuje paket za pronalazenje
        /// </summary>
        /// <param name="p">Paket za pronalazenje</param>
        public PronadjiPaketeSO(Paket p)
        {
            this.P = p;
        }


        /// <summary>
        /// Besparametarski konstruktor klase PronadjiPaketeSO  , <br/>
        /// koji nasledjije besparametarski konstruktor natklase OpstaSistemskaOperacija
        /// </summary>
        public PronadjiPaketeSO() : base()
        {

        }
        /// <summary>
        /// Javna metoda koja poziva metodu Izvrsi koja puni atribut Paketi
        /// </summary>
        /// <returns>Pakete iz baze</returns>
        public List<Paket> VratiPakete()
        {
            Izvrsi();
            return Paketi;
        }


        /// <summary>
        /// Metoda koja je nasledjena od klase OpstaSistemskaOperacija.<br/>
        /// U ovom slucaju uloga ove metode je da pozove sistemsku operaciju Pretrazi(Paket) <br/>
        /// </summary>
        /// <exception cref="Exception">U slucaju neuspelog pretrazivanja</exception>
        protected override void Izvrsi()
        {

            try
            {
                Paketi = repozitorijum.Pretrazi(P).OfType<Paket>().ToList();
            }
            catch (Exception ex)
            {
                Paketi = null;
                throw;
            }

        }
    }
}
