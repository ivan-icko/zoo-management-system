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
    /// Klasa koja predstavlja zaposlenog u zoo vrtu
    /// </summary>
    [Serializable]
    public class Zaposleni : IDomenskiObjekat
    {
        /// <value>
        /// Identifikator zaposlenog
        /// </value>
        public int IdZaposlenog { get; set; }
        /// <value>
        /// Ime zaposlenog
        /// </value>
        public string Ime { get; set; }
        /// <value>
        /// Prezime zaposlenog
        /// </value>
        public string Prezime { get; set; }
        /// <value>
        /// Korisnicko ime zaposlenog
        /// </value>
        public string KorisnickoIme { get; set; }
        /// <value>
        /// Sifra zaposlenog
        /// </value>
        public string Sifra { get; set; }

        /// <summary>
        /// Besparametarski konstruktor klase Zaposleni
        /// </summary>
        public Zaposleni() { }

        /// <value>
        /// Naziv tabele u bazi
        /// </value>
        [Browsable(false)]
        public string NazivTabele => "Zaposleni";

        /// <value>
        /// Vrednosti atributa klase Zaposleni koje ulaze u obzir u sql upitima
        /// </value>
        [Browsable(false)]
        public string Vrednosti => $"{Ime},{Prezime},{KorisnickoIme},{Sifra}";

        /// <value>
        /// Uslov u where klauzuli pri izvrsavanju sql upita
        /// </value>
        [Browsable(false)]
        public string Uslov { get; set; }

        /// <value>
        /// Nazivi kolona odgovarajucih atributa u bazi podataka
        /// </value>
        [Browsable(false)]
        public string Kolone => "(Ime,Prezime,KorisnickoIme,Sifra)";

        /// <value>
        /// Sql upit za azuriranje podataka o prijavi
        /// </value>
        public string Azuriranje { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <value>
        /// Uslov koji se postavlja u slucaju da je neophodno <br/>
        /// izvrsiti spajanje dve ili vise tabela
        /// </value>
        public string JoinUslov { get; set; }

        /// <value>
        /// Vrednost atributa klase Zaposleni, koji predstavlja <br/>
        /// primarni kljuc u bazi podataka
        /// </value>
        [Browsable(false)]
        public string IdKolona { get; } 

        /// <summary>
        /// Parametarski konsturktor
        /// </summary>
        /// <param name="ime">ime zaposlenog</param>
        /// <param name="prezime">prezime zaposlenog</param>
        /// <param name="korisnickoIme">korisnicko ime</param>
        /// <param name="sifra">korisnicka sifra</param>
        public Zaposleni(string ime, string prezime, string korisnickoIme, string sifra)
        {
            KorisnickoIme = korisnickoIme;
            Sifra = sifra;
            if (string.IsNullOrEmpty(ime)) { ime = "%"; }
            if (string.IsNullOrEmpty(prezime)) { prezime = "%"; }
            if (string.IsNullOrEmpty(korisnickoIme)) { korisnickoIme = "%"; }
            if (string.IsNullOrEmpty(sifra)) { sifra = "%"; }
            this.Uslov = $"Ime like '{ime}' and Prezime like '{prezime}' and KorisnickoIme like '{korisnickoIme}' and Sifra like '{sifra}'";
        }


        /// <summary>
        /// Funkcija koja cita jedan red iz tabele Zaposleni baze podataka
        /// </summary>
        /// <param name="reader">objekat klase SqlDataReader koji cita red</param>
        /// <returns>Zaposleni koji je materijalizovan iz baze</returns>
        public IDomenskiObjekat ProcitajRed(SqlDataReader reader)
        {
            Zaposleni z = new Zaposleni()
            {
                IdZaposlenog = (int)reader["IdZaposlenog"],
                Ime = (string)reader["Ime"],
                Prezime = (string)reader["Prezime"],
                KorisnickoIme = (string)reader["KorisnickoIme"],
                Sifra = (string)reader["Sifra"]
            };
            return z;
        }


        /// <summary>
        /// Metoda koja poredi da li su dva objekta klase Zaposleni jednaka <br/>
        /// Ako imaju isti IdZaposlenog onda su jednaka
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true ukoliko su jednaka, false ukoliko nisu</returns>
        public override bool Equals(object obj)
        {
            return obj is Zaposleni zaposleni &&
                   IdZaposlenog == zaposleni.IdZaposlenog;
        }

        /// <summary>
        /// Metoda koja postavlja id zaposlenog
        /// </summary>
        /// <param name="id">Id zaposlenog</param>
        /// <exception cref="ArgumentOutOfRangeException">Ako je id zaposlenog manji od 1</exception>
        public void SetIdZaposlenog(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id zaposlenog ne sme biti manji od 0");
            }
            IdZaposlenog = id;
        }
        /// <summary>
        /// Metoda koja vraca id zaposlenog
        /// </summary>
        /// <returns>Id zaposlenog</returns>
        public int GetIdZaposlenog()
        {
            return IdZaposlenog;
        }

        /// <summary>
        /// Metoda koja postavlja ime zaposlenog
        /// </summary>
        /// <param name="ime">Ime zaposlenog</param>
        /// <exception cref="ArgumentOutOfRangeException">Kada ne ime null</exception>
        /// <exception cref="ArgumentException">Kada je ime prazan string</exception>
        public void SetIme(string ime)
        {
            if (ime == null)
            {
                throw new ArgumentNullException("Ime ne sme biti null!");
            }

            if (ime.Trim().Length == 0 || ime == "")
            {
                throw new ArgumentException("Ime ne sme biti prazan strig!");
            }

            Ime = ime;
        }

        /// <summary>
        /// Metoda koja vraca ime posetioca
        /// </summary>
        /// <returns>Ime zaposlenog</returns>
        public string GetIme()
        {
            return Ime;
        }


        /// <summary>
        /// Metoda koja postavlja ime zaposlenog
        /// </summary>
        /// <param name="prezime">Ime zaposlenog</param>
        /// <exception cref="ArgumentOutOfRangeException">Kada ne prezime null</exception>
        /// <exception cref="ArgumentException">Kada je prezime prazan string</exception>
        public void SetPrezime(string prezime)
        {
            if (prezime == null)
            {
                throw new ArgumentNullException("Prezime ne sme biti null!");
            }

            if (prezime.Trim().Length == 0 || prezime == "")
            {
                throw new ArgumentException("Prezime ne sme biti prazan strig!");
            }

            Prezime = prezime;
        }

        /// <summary>
        /// Metoda koja vraca ime posetioca
        /// </summary>
        /// <returns>Ime zaposlenog</returns>
        public string GetPrezime()
        {
            return Prezime;
        }

        /// <summary>
        /// Metoda koja postavlja ime zaposlenog
        /// </summary>
        /// <param name="ime">Ime zaposlenog</param>
        /// <exception cref="ArgumentOutOfRangeException">Kada ne korisnicko ime null</exception>
        /// <exception cref="ArgumentException">Kada je korisnicko ime prazan string</exception>
        public void SetKorisnickoIme(string ime)
        {
            if (ime == null)
            {
                throw new ArgumentNullException("Korisnicko ime ne sme biti null!");
            }

            if (ime.Trim().Length == 0 || ime == "")
            {
                throw new ArgumentException("Korisnicko ime ne sme biti prazan strig!");
            }

            KorisnickoIme = ime;
        }

        /// <summary>
        /// Metoda koja vraca korisnicko ime posetioca
        /// </summary>
        /// <returns>Korisnicko ime zaposlenog</returns>
        public string GetKorisnickoIme()
        {
            return KorisnickoIme;
        }


        /// <summary>
        /// Metoda koja postavlja sifru zaposlenog
        /// </summary>
        /// <param name="sifra">Sifra zaposlenog</param>
        /// <exception cref="ArgumentOutOfRangeException">Kada je sifra null</exception>
        /// <exception cref="ArgumentException">Kada je sifra prazan string</exception>
        public void SetSifra(string sifra)
        {
            if (sifra == null)
            {
                throw new ArgumentNullException("Sifra ne sme biti null!");
            }

            if (sifra.Trim().Length == 0 || sifra == "")
            {
                throw new ArgumentException("Sifra ne sme biti prazan strig!");
            }

            Sifra = sifra;
        }

        /// <summary>
        /// Metoda koja vraca sifru posetioca
        /// </summary>
        /// <returns>Sifra zaposlenog</returns>
        public string GetSifra()
        {
            return Sifra;
        }


    }
}
