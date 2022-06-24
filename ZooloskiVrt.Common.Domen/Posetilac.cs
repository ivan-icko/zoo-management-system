using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooloskiVrt.Common.Domen
{
    /// <summary>
    /// Klasa koja predstavlja osobu koja posecuje zooloski vrt
    /// </summary>
    [Serializable]
    public class Posetilac : IDomenskiObjekat
    {
        /// <value>
        /// Identifikator posetioca
        /// </value>
        [Browsable(false)]
        public int IdPosetioca { get; set; }
        /// <value>
        /// Ime i prezime posetioca
        /// </value>
        public string ImeIPrezime { get; set; }
        /// <value>
        /// Broj telefona posetioca
        /// </value>
        public string Telefon { get; set; }
        /// <value>
        /// Email adresa posetioca
        /// </value>
        public string Email { get; set; }

        /// <value>
        /// Naziv tabele u bazi podataka
        /// </value>
        [Browsable(false)]
        public string NazivTabele => "Posetilac";
        /// <summary>
        /// Vrednosti atributa klase koje se azuriraju u bazi podataka
        /// </summary>
        [Browsable(false)]
        public string Vrednosti => $"{IdPosetioca},'{ImeIPrezime}','{Telefon}','{Email}'";
        /// <summary>
        /// Nazivi kolona atributa u bazi podataka
        /// </summary>
        [Browsable(false)]
        public string Kolone => "(IdPosetioca,ImeIPrezime,Telefon,Email)";

        /// <value>
        /// Where uslov sql upita
        /// </value>
        [Browsable(false)]
        public string Uslov { get; set; }
        /// <value>
        /// String koji predstavlja upit za azuriranje baze
        /// </value>
        [Browsable(false)]
        public string Azuriranje  {get;set;}
        /// <value>
        /// Sql upit koji se konstruise u slucaju potrebe za spajanjem tabela
        /// </value>
        [Browsable(false)]
        public string JoinUslov { get; set; }

        /// <value>
        ///Atribut klase koji predstavlja atribut identifikator u bazi
        /// </value>
        [Browsable(false)]
        public string IdKolona { get; }

        /// <summary>
        /// Funkcija koja cita jedan red iz tabele Posetilac baze podataka
        /// </summary>
        /// <param name="reader">objekat klase SqlDataReader</param>
        /// <returns>Objekat klase Posetilac</returns>
        public IDomenskiObjekat ProcitajRed(SqlDataReader reader)
        {
            Posetilac p = new Posetilac()
            {
                IdPosetioca = (int)reader["IdPosetioca"],
                ImeIPrezime = (string)reader["ImeIPrezime"],
                Telefon = (string)reader["Telefon"],
                Email = (string)reader["Email"]
            };
            return p;
        }
    }
}
