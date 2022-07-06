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
        /// <value>
        /// Vrednosti atributa klase koje se azuriraju u bazi podataka
        /// </value>
        [Browsable(false)]
        public string Vrednosti => $"{IdPosetioca},'{ImeIPrezime}','{Telefon}','{Email}'";
        /// <value>
        /// Nazivi kolona atributa u bazi podataka
        /// </value>
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
        public string IdKolona { get; set; }

        /// <summary>
        /// Besparametarski konsturktor
        /// </summary>
        public Posetilac() { }

      

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

        /// <summary>
        /// Metoda koja postavlja id posetioca
        /// </summary>
        /// <param name="id">id posetioca</param>
        public void SetIdPosetioca(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id ne sme biti negativan vrednost");
            }
            IdPosetioca = id;
        }
        /// <summary>
        /// Metoda koja vraca id posetioca
        /// </summary>
        /// <returns>Id posetioca</returns>
        public int GetIdPosetioca()
        {
            return IdPosetioca;
        }
        /// <summary>
        /// Metoda koja postavlja ime i prezime posetioca
        /// </summary>
        /// <param name="imeIPrezime">Ime i prezime posetioca</param>
        public void SetImeIPrezime(string imeIPrezime)
        {
            if (imeIPrezime == null)
            {
                throw new ArgumentNullException("Ime i prezime ne sme biti null!");
            }

            if (imeIPrezime.Trim().Length == 0 || imeIPrezime == "")
            {
                throw new ArgumentException("Ime i prezime ne sme biti prazan strig!");
            }

            ImeIPrezime = imeIPrezime;
        }
        /// <summary>
        /// Metoda koja vraca ime i prezime posetioca
        /// </summary>
        /// <returns>Ime i prezime posetioca</returns>
        public string GetImeIPrezime()
        {
            return ImeIPrezime;
        }

        /// <summary>
        /// Metoda koja postavlja telefon posetioca
        /// </summary>
        /// <param name="telefon">Telefon posetioca</param>
        public void SetTelefon(string telefon)
        {
            if (telefon == null)
            {
                throw new ArgumentNullException("Telefon ne sme biti null!");
            }

            if (telefon.Trim().Length == 0 || telefon == "")
            {
                throw new ArgumentException("Telefon ne sme biti prazan strig!");
            }

            Telefon = telefon;
        }

        /// <summary>
        /// Metoda koja vraca telefon posetioca
        /// </summary>
        /// <returns>Telefon posetioca</returns>
        public string GetTelefon()
        {
            return Telefon;
        }
        /// <summary>
        /// Metoda koja vraca email
        /// </summary>
        /// <param name="email">Email</param>
        public void SetEmail(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("Email ne sme biti null!");
            }

            if (email.Trim().Length == 0 || email == "")
            {
                throw new ArgumentException("Email ne sme biti prazan strig!");
            }

            Email = email;
        }
        /// <summary>
        /// Metoda koja vraca email posetioca
        /// </summary>
        /// <returns>Email posetioca</returns>
        public string GetEmail()
        {
            return Email;
        }

        /// <summary>
        /// Equals metoda koja poredi dve instance klase Posetilac i to njihove id-eve
        /// </summary>
        /// <param name="obj">Objekat klase Posetilac</param>
        /// <returns>True ako su isti, false ako nisu </returns>
        public override bool Equals(object obj)
        {
            return obj is Posetilac posetilac &&
                   IdPosetioca == posetilac.IdPosetioca;
        }
    }
}
