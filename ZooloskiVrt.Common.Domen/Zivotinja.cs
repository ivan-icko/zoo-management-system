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
    public class Zivotinja : IDomenskiObjekat
    {
        [Browsable(false)]
        public int IdZivotinje { get; set; }
        public string Vrsta { get; set; }
        public int OznakaZivotinje { get; set; }
        public Pol Pol { get; set; }
        public int Starost { get; set; }
        public string Staniste { get; set; }
        public TipIshrane TipIshrane { get; set; }

        public Zivotinja() { }

        [Browsable(false)]
        public string NazivTabele => "Zivotinja";
        [Browsable(false)]
        public string Vrednosti => $"{OznakaZivotinje},'{Vrsta}','{Pol}',{Starost},'{Staniste}','{TipIshrane}'";
        [Browsable(false)]
        public string Uslov {get;set;}
        [Browsable(false)]
        public string Kolone => "(OznakaZivotinje,Vrsta,Pol,Starost,Staniste,TipIshrane)";
        [Browsable(false)]
        public string Azuriranje => $"OznakaZivotinje={OznakaZivotinje},Vrsta='{Vrsta}',Pol='{Pol}',Starost={Starost},Staniste='{Staniste}',TipIshrane='{TipIshrane}'";

        public string JoinUslov { get; set; }
        public string IdKolona { get; } = "IdZivotinje";

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

        public override bool Equals(object obj)
        {
            return obj is Zivotinja zivotinja &&
                   IdZivotinje == zivotinja.IdZivotinje;
        }

        /// <summary>
        /// Metoda koja postavlja id zivotinje
        /// </summary>
        /// <param name="id">Id zivotinje</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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
