using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooloskiVrt.Common.Domen
{
    [Serializable]
    public class Prijava : IDomenskiObjekat
    {
        [Browsable(false)]
        public int IdPaketa { get; set; }
        [Browsable(false)]
        public int IdPosetioca { get; set; }
        public DateTime DatumPrijave { get; set; }
        public int BrojOsoba { get; set; }




        public string NazivTabele => "Prijava";

        public string Vrednosti => $"{IdPaketa},{IdPosetioca},'{DatumPrijave}',{BrojOsoba}";

        public string Kolone => "(IdPaketa,IdPosetioca,DatumPrijave,BrojOsoba)";

        public string Uslov { get; set; }

        public string Azuriranje { get; set; }

        public string JoinUslov { get; set; }
        public string IdKolona { get; }

        public override bool Equals(object obj)
        {
            return obj is Prijava prijava &&
                   IdPaketa == prijava.IdPaketa &&
                   IdPosetioca == prijava.IdPosetioca;
        }

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
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void SetIdPosetioca(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id posetioca ne sme biti manji od 0");
            }
            IdPosetioca = id;
        }

        public int GetIdPosetioca()
        {
            return IdPosetioca;
        }
        /// <summary>
        /// Metoda koja postalvlja datum prijave na paket
        /// </summary>
        /// <param name="datum">Datum prijave</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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
