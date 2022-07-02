using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;

namespace ZooloskiVrt.Server.SistemskeOperacije
{

    /// <summary>
    /// Klasa koja predstavlja sistemsku operaciju pronalazenja zivotinje
    /// </summary>
    public class PronadjiZivotinjeSO : OpstaSistemskaOperacija
    {
        /// <value>
        /// Javni atribut Zivotinje koji predstavlja listu zivotinja koje je potrebno vratiti iz baze
        /// </value>
        public List<Zivotinja> Zivotinje { get; set; } = new List<Zivotinja>();


        /// <value>
        /// Javni atribut ZIvotinje koji sadrzi atribute po kojima se traze zadate zivotinje 
        /// </value>
        public Zivotinja Z { get; set; }

        /// <summary>
        /// Parametarski konstruktor klase PronadjiZivotinjeSO, koji inicijalizuje zivotinju za pronalazenje
        /// </summary>
        /// <param name="z">Zivotinja za pronalazenje</param>
        public PronadjiZivotinjeSO(Zivotinja z)
        {
            Z = z;
        }

        /// <summary>
        /// Besparametarski konstruktor klase PronadjiZovotinjeSO  , <br/>
        /// koji nasledjije besparametarski konstruktor natklase OpstaSistemskaOperacija
        /// </summary>
        public PronadjiZivotinjeSO():base()
        {

        }

        /// <summary>
        /// Javna metoda koja poziva metodu Izvrsi koja puni atribut Zivotinje
        /// </summary>
        /// <returns>Zivotinje iz baze</returns>
        public List<Zivotinja> VratiZivotinje()
        {
            Izvrsi();
            return Zivotinje;
        }


        /// <summary>
        /// Metoda koja je nasledjena od klase OpstaSistemskaOperacija.<br/>
        /// U ovom slucaju uloga ove metode je da pozove sistemsku operaciju Pretrazi(Zivotinja) <br/>
        /// </summary>
        /// <exception cref="Exception">U slucaju neuspelog pretrazivanja</exception>
        protected override void Izvrsi()
        {
            try
            {
                Zivotinje = repozitorijum.Pretrazi(Z).OfType<Zivotinja>().ToList();
            }
            catch (Exception ex)
            {
                Zivotinje = null;
                throw;
            }

        }
    }
}
