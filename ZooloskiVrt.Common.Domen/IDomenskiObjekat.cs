using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooloskiVrt.Common.Domen
{
    public interface IDomenskiObjekat
    {
        /// <value>
        ///Postavlja naziv tabele odredjene klase u bazi podataka
        /// </value>
        string NazivTabele { get; }
        /// <value>
        /// Postavlja vrednosti koje je potrebno azurirati u bazi
        /// </value>
        string Vrednosti { get; }
        /// <value>
        /// Predstavlja kolone tabele u koje se klasa pretvara
        /// </value>
        string Kolone { get; }
        /// <value>
        /// Predstavlja uslov sql upita
        /// </value>
        string Uslov { get; set; }
        /// <value>
        /// Predstavlja update uslov sql upita
        /// </value>
        string Azuriranje { get; }
        /// <value>
        /// Predstavlja uslova spajanja dve lil vise tabela u bazi podataka
        /// </value>
        string JoinUslov { get; set; }
        /// <value>
        /// Predstavlja kolonu koja identifikuje red u tabeli baze podataka
        /// </value>
        string IdKolona { get; }
        
        /// <summary>
        /// Pretvara jedan red tabele baze podataka u jedan objekat odgovarajuce klase
        /// </summary>
        /// <param name="rezultat">Predstavlja red baze podataka</param>
        /// <returns>IdomenskiObjekat koji se konvertuje u odgovarajuci objekat klase</returns>
        IDomenskiObjekat ProcitajRed(SqlDataReader rezultat);
    }
}
