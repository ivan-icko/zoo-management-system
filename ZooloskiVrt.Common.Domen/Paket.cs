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
    /// Klasa koja predstavlja paket zivotinja na koji <br/>
    /// korisnik moze da se prijavi i da ih poseti
    /// </summary>
    [Serializable]
    public class Paket : IDomenskiObjekat
    {
        /// <value>
        /// Identifikator paketa
        /// </value>
        [Browsable(false)]
        public int IdPaketa { get; set; }
        /// <value>
        /// Predstavlja ime paketa
        /// </value>
        public string NazivPaketa { get; set; }

        /// <value>
        /// Iznos cene jednog paketa
        /// </value>
        public double Cena { get; set; }

        /// <value>
        /// Datum do kojeg je ponuda paketa aktivna
        /// </value>
        public DateTime DatumDo { get; set; }

        /// <value>
        /// Bezparametarski konstruktor klase Paket
        /// </value>
        public Paket()
        {

        }

        /// <value>
        /// Lista celobrojnih objekata
        /// </value>
        [Browsable(false)]
        public List<int> ListaIdjevaZivotinja = new List<int>();

        /// <value>
        /// Naziv tabele u bazi za koju se vezuje klasa Paket
        /// </value>
        [Browsable(false)]
        public string NazivTabele => "Paket";

        /// <value>
        /// Vrednosti atributa klase Paket koje ulaze u obzir u sql upitima
        /// </value>
        [Browsable(false)]
        public string Vrednosti => $"'{NazivPaketa}',{Cena},'{DatumDo}'";

        /// <value>
        /// Nazivi kolona odgovarajucih atributa u bazi podataka
        /// </value>
        [Browsable(false)]
        public string Kolone => "(NazivPaketa,Cena,DatumDo)";

        /// <value>
        /// Uslov u where klauzuli pri izvrsavanju sql upita
        /// </value>
        [Browsable(false)]
        public string Uslov { get; set; }

        /// <summary>
        /// Sql upit za azuriranje podataka o paketu
        /// </summary>
        [Browsable(false)]
        public string Azuriranje => $"NazivPaketa='{NazivPaketa}', Cena={Cena}, DatumDo='{DatumDo}'";

        /// <value>
        /// Uslov koji se postavlja u slucaju da je neophodno <br/>
        /// izvrsiti spajanje dve ili vise tabela
        /// </value>
        [Browsable(false)]
        public string JoinUslov { get; set;}

        /// <summary>
        /// Vrednost atributa klase Paket, koji predstavlja <br/>
        /// primarni kljuc u bazi podataka
        /// </summary>
        [Browsable(false)]
        public string IdKolona { get; } = "IdPaketa";


        /// <summary>
        /// Funkcija koja cita jedan red iz tabele Paket baze podataka
        /// </summary>
        /// <param name="reader">objekat klase SqlDataReader koji cita red</param>
        /// <returns>Paket koji je materijalizovan iz baze</returns>
        public IDomenskiObjekat ProcitajRed(SqlDataReader reader)
        {
            Paket p = new Paket()
            {
                IdPaketa = (int)reader["IdPaketa"],
                NazivPaketa=(string)reader["NazivPaketa"],
                Cena = (double)reader["Cena"],
                DatumDo = (DateTime)reader["DatumDo"]
            };
            return p;
        }

        /// <summary>
        /// Konstruktor koji generise uslov sql upita u odnosu na postavljene parametre
        /// </summary>
        /// <param name="id">id paketa</param>
        /// <param name="nazivPaketa">naziv paketa</param>
        /// <param name="cena">cena paketa</param>
        /// <param name="datumDo">datum do kada je paket aktivan</param>
        public Paket(string id, string nazivPaketa, string cena,string datumDo)
        {
            if (string.IsNullOrEmpty(id)) { id = "%"; }
            if (string.IsNullOrEmpty(nazivPaketa)) { nazivPaketa = "%"; }
            if (string.IsNullOrEmpty(cena)) { cena = "%"; }
            if (string.IsNullOrEmpty(datumDo)) {datumDo = "%"; }
          
            this.Uslov = $"cast(IdPaketa as nvarchar(10)) like '{id}' and NazivPaketa like '{nazivPaketa}' and cast(Cena as float) like '{cena}' and DatumDo like '{datumDo}'";
        }


        public int GetIdPaketa()
        {
            return IdPaketa;
        }

        public void SetIdPaketa(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentOutOfRangeException("Id ne sme biti manji od 0!");
            }

            IdPaketa=id;
        }

        public void SetNazivPaketa(string naziv)
        {
            if (naziv == null)
            {
                throw new ArgumentNullException("Naziv ne sme biti null!");
            }

            if (naziv.Trim().Length == 0 || naziv == "")
            {
                throw new ArgumentException("Naziv ne sme biti prazan strig!");
            }

            NazivPaketa = naziv;

        }

        public string GetNazivPaketa()
        {
            return NazivPaketa;
        }

        public void SetCena(double cena)
        {
            if (cena < 0)
            {
                throw new ArgumentOutOfRangeException("Cena ne sme biti manja od 0");
            }
            Cena = cena;
        }

        public double GetCena()
        {
            return Cena;
        }

        public void SetdDatumDo(DateTime datum)
        {
           
            if (datum < DateTime.Now)
            {
                throw new ArgumentOutOfRangeException("Datum ne sme biti u proslosti");
            }
            DatumDo = datum;
        }

        public DateTime GetDatumDo()
        {
            return DatumDo;
        }

        public override bool Equals(object obj)
        {
            return obj is Paket paket &&
                   IdPaketa == paket.IdPaketa &&
                   NazivPaketa == paket.NazivPaketa &&
                   Cena == paket.Cena &&
                   DatumDo == paket.DatumDo;
        }
    }
}
