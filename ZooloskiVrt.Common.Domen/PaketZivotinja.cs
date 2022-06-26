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




        /// <summary>
        /// Funckija koja postavlja identifikator zivotinje
        /// </summary>
        /// <param name="id">id zivotinje</param>
        public void SetIdZivotinje(int id)
        {
            if (id< 0)
            {
                throw new ArgumentOutOfRangeException("Id zivotinje ne sme biti manji od 0");
            }
            IdZivotinje = id;
        }

        /// <summary>
        /// Funkcija koja vraca id zivotinje
        /// </summary>
        /// <returns>Id zivotinje</returns>
        public int GetIdZivotinje()
        {
            return IdZivotinje;
        }

        /// <summary>
        /// Funkcija koja postavlja identifikator paketa
        /// </summary>
        /// <param name="id">id paketa</param>
        public void SetIdPaketa(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id paketa ne sme biti manji od 0");
            }
            IdPaketa = id;
        }
        /// <summary>
        /// Funkcija koja braca id paketa
        /// </summary>
        /// <returns></returns>
        public int GetIdPaketa()
        {
            return IdPaketa;
        }
    }
}
