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
    /// Klasa koja predstavlja asocijativnu vezu klase Posetilac i klase Prijava
    /// </summary>
    [Serializable]
    public class PosetilacPrijava : IDomenskiObjekat
    {
        /// <value>
        /// Ime i prezime posetioca
        /// </value>
        public string ImeIPrezime { get; set; }
        /// <value>
        /// Naziv paketa koji je rezervisao
        /// </value>
        public string NazivPaketa { get; set; }
        /// <value>
        /// Broj telefona posetioca
        /// </value>
        public string Telefon { get; set; }

        /// <value>
        /// Email adresa posetioca
        /// </value>
        public string Email { get; set; }

        /// <value>
        /// Broj osoba na jednom paketu
        /// </value>
        public int BrojOsoba { get; set; }

        /// <value>
        /// Datum rezirvisanja paketa
        /// </value>
        public DateTime Datum { get; set; }

        /// <value>
        /// Naziv tabele u bazi podataka
        /// </value>
        [Browsable(false)]
        public string NazivTabele =>"Posetilac";

        /// <value>
        /// Vrednosti atributa klase koji se dematerijalizuju u kolone baze
        /// </value>
        [Browsable(false)]
        public string Vrednosti => $"'{ImeIPrezime}','{NazivPaketa}','{Telefon}','{Email}',{BrojOsoba},'{Datum}";

        /// <value>
        /// Naziv kolona ove klase u bazi podataka
        /// </value>
        [Browsable(false)]
        public string Kolone =>"ImeIPrezime,NazivPaketa,Telefon,Email,BrojOsoba,Datum";

        /// <value>
        /// Where uslov sql upita
        /// </value>
        [Browsable(false)]
        public string Uslov { get; set; }
        /// <value>
        /// String koji predstavlja upit za azuriranje baze
        /// </value>
        [Browsable(false)]
        public string Azuriranje { get; set; }

        /// <value>
        /// String koji predstavlja sql uslov za spajanje tabela
        /// </value>
        [Browsable(false)]
        public string JoinUslov { get; set; }

        /// <value>
        /// Atribut klase koji predstavlja jedinstveni identifikator reda u bazi
        /// </value>
        [Browsable(false)]
        public string IdKolona { get; }

        /// <summary>
        /// Funkcija koja cita jedan red iz tabele PosetilacPrijava baze podataka
        /// </summary>
        /// <param name="reader">objekat klase SqlDataReader</param>
        /// <returns>Objekat klase PosetilacPrijava</returns>
        public IDomenskiObjekat ProcitajRed(SqlDataReader reader)
        {
            PosetilacPrijava pp = new PosetilacPrijava()
            {
                ImeIPrezime = (string)reader["ImeIPrezime"],
                NazivPaketa=(string)reader["NazivPaketa"],
                Telefon = (string)reader["Telefon"],
                Email = (string)reader["Email"],
                BrojOsoba = (int)reader["BrojOsoba"],
                Datum = (DateTime)reader["DatumPrijave"]
            };
            return pp;
        }

        public void SetImeIPrezime(string imeIPrezime)
        {
            if (imeIPrezime == null)
            {
                throw new ArgumentNullException("Ime i prezime ne sme biti null!");
            }

            if (imeIPrezime.Trim().Length == 0 || imeIPrezime == "")
            {
                throw new ArgumentException("Ime i prezime ne sme biti prazan string!");
            }

            ImeIPrezime = imeIPrezime;
        }
        
        public string GetImeIPrezime()
        {
            return ImeIPrezime;
        }


        public void SetNazivPaketa(string naziv)
        {
            if (naziv == null)
            {
                throw new ArgumentNullException("Naziv paketa ne sme biti null!");
            }

            if (naziv.Trim().Length == 0 || naziv == "")
            {
                throw new ArgumentException("Naziv paketa ne sme biti prazan string!");
            }

            NazivPaketa = naziv;
        }

        public string GetNazivPaketa()
        {
            return NazivPaketa;
        }

        public void SetTelefon(string telefon)
        {
            if (telefon == null)
            {
                throw new ArgumentNullException("Telefon ne sme biti null!");
            }

            if (telefon.Trim().Length == 0 || telefon == "")
            {
                throw new ArgumentException("Telefon ne sme biti prazan string!");
            }

            Telefon = telefon;
        }

        public string GetTelefon()
        {
            return Telefon;
        }


        public void SetEmail(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("Email ne sme biti null!");
            }

            if (email.Trim().Length == 0 || email == "")
            {
                throw new ArgumentException("Email ne sme biti prazan string!");
            }

            Email = email;
        }

        public string GetEmail()
        {
            return Email;
        }

        public void SetBrojOsoba(int broj)
        {
            if (BrojOsoba < 1)
            {
                throw new ArgumentOutOfRangeException("Broj osoba mora biti veci od 0");
            }
            BrojOsoba = broj;
        }





    }
}
