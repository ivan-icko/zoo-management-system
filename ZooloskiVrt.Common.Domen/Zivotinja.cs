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
    /// Klasa koja predstavlja zivotinju u zoo vrtu
    /// </summary>
    [Serializable]
    public class Zivotinja : IDomenskiObjekat
    {
        /// <value>
        /// Identifikator zivotinje
        /// </value>
        [Browsable(false)]
        public int IdZivotinje { get; set; }
        /// <value>
        /// Vrsta zivotinje
        /// </value>
        public string Vrsta { get; set; }
        /// <value>
        /// Oznaka zivotinje
        /// </value>
        public int OznakaZivotinje { get; set; }
        /// <value>
        /// Pol zivotinje
        /// </value>
        public Pol Pol { get; set; }

        /// <value>
        /// Starost zivotinje
        /// </value>
        public int Starost { get; set; }
        /// <value>
        /// Staniste zivotinje
        /// </value>
        public string Staniste { get; set; }
        /// <value>
        /// Tip ishrane zivotinje
        /// </value>
        public TipIshrane TipIshrane { get; set; }

        /// <summary>
        /// Besparametarski konstruktor klase Zivotinja
        /// </summary>
        public Zivotinja() { }

        /// <value>
        /// Naziv tabele u bazi
        /// </value>
        [Browsable(false)]
        public string NazivTabele => "Zivotinja";

        /// <value>
        /// Vrednosti atributa klase Zivotinja koje ulaze u obzir u sql upitima
        /// </value>
        [Browsable(false)]
        public string Vrednosti => $"{OznakaZivotinje},'{Vrsta}','{Pol}',{Starost},'{Staniste}','{TipIshrane}'";

        /// <value>
        /// Uslov u where klauzuli pri izvrsavanju sql upita
        /// </value>
        [Browsable(false)]
        public string Uslov {get;set;}

        /// <value>
        /// Nazivi kolona odgovarajucih atributa u bazi podataka
        /// </value>
        [Browsable(false)]
        public string Kolone => "(OznakaZivotinje,Vrsta,Pol,Starost,Staniste,TipIshrane)";

        /// <value>
        /// Sql upit za azuriranje podataka o prijavi
        /// </value>
        [Browsable(false)]
        public string Azuriranje => $"OznakaZivotinje={OznakaZivotinje},Vrsta='{Vrsta}',Pol='{Pol}',Starost={Starost},Staniste='{Staniste}',TipIshrane='{TipIshrane}'";

        /// <value>
        /// Uslov koji se postavlja u slucaju da je neophodno <br/>
        /// izvrsiti spajanje dve ili vise tabela
        /// </value>
        [Browsable(false)]
        public string JoinUslov { get; set; }

        /// <value>
        /// Vrednost atributa klase Zaposleni, koji predstavlja <br/>
        /// primarni kljuc u bazi podataka
        /// </value>
        [Browsable(false)]
        public string IdKolona { get; } = "IdZivotinje";


        /// <summary>
        /// Parametarski konstruktor koji postavlja vrednosti odgovarajucih propertija
        /// </summary>
        /// <param name="id">Id zivotinje</param>
        /// <param name="oznakaZivotinje">Oznaka zivotinje</param>
        /// <param name="vrsta">Vrsta zivotinje</param>
        /// <param name="pol">Pol zivotinje</param>
        /// <param name="starost">Starost zivotinje</param>
        /// <param name="staniste">Staniste zivotinje</param>
        /// <param name="tipIshrane">Tip ishrane zivotinje</param>
        public Zivotinja(string id,string oznakaZivotinje,string vrsta,string pol, string starost, string staniste, string tipIshrane)
        {
            if (string.IsNullOrEmpty(id)) { id = "%"; }
            if (string.IsNullOrEmpty(oznakaZivotinje)) { oznakaZivotinje = "%"; }
            if (string.IsNullOrEmpty(vrsta)) { vrsta = "%"; }
            if (string.IsNullOrEmpty(pol)) { pol = "%"; }
            if (string.IsNullOrEmpty(starost)) { starost = "%"; }
            if (string.IsNullOrEmpty(staniste)) { staniste = "%"; }
            if (string.IsNullOrEmpty(tipIshrane)) { tipIshrane = "%"; }
            this.Uslov = $"cast(IdZivotinje as nvarchar(10)) like '{id}' and cast(OznakaZivotinje as nvarchar(10)) like '{oznakaZivotinje}' and Vrsta like '{vrsta}' and pol like '{pol}' and cast(Starost as nvarchar(10)) like '{starost}' and Staniste like '{staniste}' and TipIshrane like '{tipIshrane}'";
        }


        /// <summary>
        /// Funkcija koja cita jedan red iz tabele Zivotinja baze podataka
        /// </summary>
        /// <param name="reader">objekat klase SqlDataReader koji cita red</param>
        /// <returns>Zivotinja koji je materijalizovana iz baze</returns>
        public IDomenskiObjekat ProcitajRed(SqlDataReader reader)
        {
            Zivotinja z = new Zivotinja()
            {
                IdZivotinje = (int)reader["IdZivotinje"],
                OznakaZivotinje = (int)reader["OznakaZivotinje"],
                Vrsta = (string)reader["Vrsta"],
                Pol = (Pol)Enum.Parse(typeof(Pol),(string)reader["Pol"]),
                Starost = (int)reader["Starost"],
                Staniste = (string)reader["Staniste"],
                TipIshrane = (TipIshrane)Enum.Parse(typeof(TipIshrane), (string)reader["TipIshrane"])
            };
            return z;
        }

        /// <summary>
        /// Metoda koja poredi da li su dva objekta klase Zivotinja jednaka <br/>
        /// Ako imaju isti IdZivotinje onda su jednaka
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true ukoliko su jednaka, false ukoliko nisu</returns>
        public override bool Equals(object obj)
        {
            return obj is Zivotinja zivotinja &&
                   IdZivotinje == zivotinja.IdZivotinje;
        }

        /// <summary>
        /// Metoda koja postavlja id zivotinje
        /// </summary>
        /// <param name="id">Id zivotinje</param>
        /// <exception cref="ArgumentOutOfRangeException">Ako je id zivotinje manji od 0</exception>
        public void SetIdZivotinje(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Id zivotinje ne sme biti manji od 0");
            }
            IdZivotinje = id;
        }

        /// <summary>
        /// Metoda koja vraca id zivotinje
        /// </summary>
        /// <returns>Id zivotinje</returns>
        public int GetIdZivotinje()
        {
            return IdZivotinje;
        }

        /// <summary>
        /// Metoda koja postavlja vrstu zivotinje
        /// </summary>
        /// <param name="vrsta">Vrsta zivotinje</param>
        /// <exception cref="ArgumentOutOfRangeException">Kada ne vrsta null</exception>
        /// <exception cref="ArgumentException">Kada je vrsta prazan string</exception>
        public void SetVrsta(string vrsta)
        {
            if (vrsta == null)
            {
                throw new ArgumentNullException("Vrsta ne sme biti null!");
            }

            if (vrsta.Trim().Length == 0 || vrsta == "")
            {
                throw new ArgumentException("Vrsta ne sme biti prazan strig!");
            }

            Vrsta = vrsta;
        }

        /// <summary>
        /// Metoda koja vraca vrstu zivotinje
        /// </summary>
        /// <returns>Vrsta zivotinje</returns>
        public string GetVrsta()
        {
            return Vrsta;
        }

        /// <summary>
        /// Metoda koja postavlja oznaku zivotinje
        /// </summary>
        /// <param name="id">Oznaka zivotinje</param>
        /// <exception cref="ArgumentOutOfRangeException">Kada je oznaka zivotinje manja od 0</exception>
        public void SetOznakaZivotinje(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("Oznaka zivotinje ne sme biti manji od 0");
            }
            OznakaZivotinje = id;
        }
        /// <summary>
        /// Metoda koja vraca oznaku zivotinje
        /// </summary>
        /// <returns>Oznaka zivotinje</returns>
        public int GetOznakaZivotinje()
        {
            return OznakaZivotinje;
        }


        /// <summary>
        /// Metoda koja postavlja starost zivotinje
        /// </summary>
        /// <param name="starost">Starost zivotinje</param>
        /// <exception cref="ArgumentOutOfRangeException">Kada je starost zivotinje manja od 0 dana</exception>
        public void SetStarost(int starost)
        {
            if (starost < 0)
            {
                throw new ArgumentOutOfRangeException("Starost zivotinje ne sme biti manji od 0 godina");
            }
            Starost = starost;
        }
        /// <summary>
        /// Metoda koja vraca starost zivotinje
        /// </summary>
        /// <returns>Starost zivotinje</returns>
        public int GetStarost()
        {
            return Starost;
        }






        /// <summary>
        /// Metoda koja postavlja staniste zivotinje
        /// </summary>
        /// <param name="staniste">Staniste zivotinje</param>
        /// <exception cref="ArgumentOutOfRangeException">Kada je staniste null</exception>
        /// <exception cref="ArgumentException">Kada je staniste prazan string</exception>
        public void SetStaniste(string staniste)
        {
            if (staniste == null)
            {
                throw new ArgumentNullException("Staniste ne sme biti null!");
            }

            if (staniste.Trim().Length == 0 || staniste == "")
            {
                throw new ArgumentException("Staniste ne sme biti prazan strig!");
            }

            Staniste = staniste;
        }

        /// <summary>
        /// Metoda koja vraca staniste zivotinje
        /// </summary>
        /// <returns>Staniste zivotinje</returns>
        public string GetStaniste()
        {
            return Staniste;
        }

    }
}
