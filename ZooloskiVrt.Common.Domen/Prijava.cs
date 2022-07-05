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
    /// Klasa koja predstavlja prijavu posetioca <br/>
    /// na jedan od ponudjenih paketa
    /// </summary>
    [Serializable]
    public class Prijava : IDomenskiObjekat
    {
        /// <value>
        /// Identifikator paketa
        /// </value>
        [Browsable(false)]
        public int IdPaketa { get; set; }
        /// <value>
        /// Identifikator posetioca
        /// </value>
        [Browsable(false)]
        public int IdPosetioca { get; set; }

        /// <value>
        /// Datum prijave na paket
        /// </value>
        public DateTime DatumPrijave { get; set; }


        /// <value>
        /// Broj osoba prijavljenih na paket
        /// </value>
        public int BrojOsoba { get; set; }



        /// <value>
        /// Naziv tabele
        /// </value>
        public string NazivTabele => "Prijava";


        /// <value>
        /// Vrednosti atributa klase Prijava koje ulaze u obzir u sql upitima
        /// </value>
        public string Vrednosti => $"{IdPaketa},{IdPosetioca},'{DatumPrijave}',{BrojOsoba}";

        /// <value>
        /// Nazivi kolona odgovarajucih atributa u bazi podataka
        /// </value>
        public string Kolone => "(IdPaketa,IdPosetioca,DatumPrijave,BrojOsoba)";

        /// <value>
        /// Uslov u where klauzuli pri izvrsavanju sql upita
        /// </value>
        public string Uslov { get; set; }

        /// <value>
        /// Sql upit za azuriranje podataka o prijavi
        /// </value>
        public string Azuriranje { get; set; }


        /// <value>
        /// Uslov koji se postavlja u slucaju da je neophodno <br/>
        /// izvrsiti spajanje dve ili vise tabela
        /// </value>
        public string JoinUslov { get; set; }

        /// <value>
        /// Vrednost atributa klase Prijava, koji predstavlja <br/>
        /// primarni kljuc u bazi podataka
        /// </value>
        public string IdKolona { get; }


        /// <summary>
        /// Metoda koja poredi da li su dva objekta klase Prijava jednaka <br/>
        /// Ako imaju isti IdPaketa i IdPosetioca onda su jednaka
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true ukoliko su jednaka, false ukoliko nisu</returns>
        public override bool Equals(object obj)
        {
            return obj is Prijava prijava &&
                   IdPaketa == prijava.IdPaketa &&
                   IdPosetioca == prijava.IdPosetioca;
        }


        /// <summary>
        /// Funkcija koja cita jedan red iz tabele Prijava baze podataka
        /// </summary>
        /// <param name="reader">objekat klase SqlDataReader koji cita red</param>
        /// <returns>Prijava koji je materijalizovana iz baze</returns>
        public IDomenskiObjekat ProcitajRed(SqlDataReader reader)
        {
            Prijava p = new Prijava()
            {
                IdPaketa = (int)reader["IdPaketa"],
                IdPosetioca = (int)reader["IdPosetioca"],
                DatumPrijave = (DateTime)reader["DatumPrijave"],
                BrojOsoba = (int)reader["BrojOsoba"]
            };
            return p;
        }

        /// <summary>
        /// Metoda koja postavlja id paketa
        /// </summary>
        /// <param name="id">Id paketa</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetIdPaketa(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id paketa ne sme biti manji od 0");
            }
            IdPaketa = id;
        }
        /// <summary>
        /// Metoda koja vraca id paket
        /// </summary>
        /// <returns>Id paketa</returns>
        public int GetIdPaketa()
        {
            return IdPaketa;
        }
        /// <summary>
        /// Metoda koja postavlja id posetioca
        /// </summary>
        /// <param name="id">Id posetioca</param>
        /// <exception cref="ArgumentOutOfRangeException">Ako je id manji od 0</exception>
        public void SetIdPosetioca(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id posetioca ne sme biti manji od 0");
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
        /// Metoda koja postalvlja datum prijave na paket
        /// </summary>
        /// <param name="datum">Datum prijave</param>
        /// <exception cref="ArgumentOutOfRangeException">Ako je datum u prostlosti</exception>
        public void SetdDatumPrijave(DateTime datum)
        {

            if (datum < DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("Datum ne sme biti u proslosti");
            }
            DatumPrijave = datum;
        }
        /// <summary>
        /// Funckija koja vraca datum paketa
        /// </summary>
        /// <returns>Datum do</returns>
        public DateTime GetDatumPrijave()
        {
            return DatumPrijave;
        }
        /// <summary>
        /// Metoda koja vraca broj osoba na paketu
        /// </summary>
        /// <param name="broj">Broj osoba</param>
        /// <exception cref="ArgumentOutOfRangeException">Ako je broj osoba manji od 1</exception>
        public void SetBrojOsoba(int broj)
        {
            if (broj < 1)
            {
                throw new ArgumentOutOfRangeException("Broj osoba ne sme biti manji od 1");
            }
            BrojOsoba = broj;
        }
        /// <summary>
        /// Metoda koja vraca broj osoba na paketu
        /// </summary>
        /// <returns>Broj osoba</returns>
        public int GetBrojOsoba()
        {
            return BrojOsoba;
        }

    }
}
