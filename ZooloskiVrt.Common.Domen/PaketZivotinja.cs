using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooloskiVrt.Common.Domen
{

    /// <summary>
    /// Asocijativna klasa koja objedinjuje zivotinju sa paketom kojem pripada
    /// </summary>
    [Serializable]
    public class PaketZivotinja : IDomenskiObjekat
    {
        /// <value>
        /// Identifikator zivotinje
        /// </value>
        public int IdZivotinje { get; set; }
        /// <value>
        /// Identifikator paketa
        /// </value>
        public int IdPaketa { get; set; }

        /// <value>
        /// Naziv tabele u bazi podataka
        /// </value>
        public string NazivTabele => "PaketZivotinja";

        /// <value>
        /// Vrednosti klase koje odgovaraju kljucnim atributima u tabeli baze
        /// </value>
        public string Vrednosti => $"{IdPaketa},{IdZivotinje}";

        /// <value>
        /// Nazivi kolona ove klase u bazi podataka
        /// </value>
        public string Kolone => "(IdPaketa,IdZivotinje)";


        /// <value>
        /// Where uslov sql upita
        /// </value>
        public string Uslov
        {
            get;set;
        }


        

        /// <summary>
        /// Neimplementiran property koji azurira instancu klase
        /// </summary>
        public string Azuriranje => throw new NotImplementedException();

        /// <summary>
        /// Sql upit koji se konstruise u slucaju potrebe za spajanjem tabela. <br/>
        /// Property je neimplementiran
        /// </summary>
        public string JoinUslov { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <value>
        /// Atribut klase koji predstavlja atribut identifikator u bazi
        /// </value>
        public string IdKolona => throw new NotImplementedException();


        /// <summary>
        /// Funkcija koja cita jedan red iz tabele PaketZivotinja baze podataka
        /// </summary>
        /// <param name="rezultat">rezultat</param>
        /// <exception cref="NotImplementedException"></exception>
        public IDomenskiObjekat ProcitajRed(SqlDataReader rezultat)
        {
            throw new NotImplementedException();
        }
    }
}
