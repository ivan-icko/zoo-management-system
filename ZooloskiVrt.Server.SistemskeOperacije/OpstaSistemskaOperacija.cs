using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;
using ZooloskiVrt.Server.Repozitorujum;

namespace ZooloskiVrt.Server.SistemskeOperacije
{
    /// <summary>
    /// Apstraktna klasa koja predstavlja srz svake sistemske operacije
    /// </summary>
    public abstract class OpstaSistemskaOperacija
    {
        /// <value>
        /// Atribut koji predstavlja repozitorijum
        /// </value>
        protected IRepozitorijum<IDomenskiObjekat> repozitorijum;

        /// <summary>
        /// Besparametarski konstruktor koji postavlja vrednost atributa repozitorijum
        /// </summary>
        public OpstaSistemskaOperacija()
        {
            this.repozitorijum = new GenerickiRepozitorujum();
        }

        /// <summary>
        /// Javna metoda koja izvrsava neku od generickih operacija ka baze. <br/>
        /// Otvara konekciju, zapocinje transakciju, izvrsava akciju i komituje u slucaju da je sve proslo kako treba.
        /// <br/>, u suprotnom vrsi ponistavanje dejstva akcije na bazu podataka
        /// </summary>
        public void IzvrsiTemplejt()
        {
            try
            {
                repozitorijum.OtvoriKonekciju();
                repozitorijum.ZapocniTransakciju();
                Izvrsi();
                repozitorijum.Commit();

            }
            catch (Exception ex)
            {
                repozitorijum.Rollback();
                Console.WriteLine(ex.Message);
            }
            finally
            {
                repozitorijum.ZatvoriKonekciju();
            }
        }

        /// <summary>
        /// Apstraktna metoda koja izvrsava specificnu akciju ka bazi podataka
        /// </summary>
        protected abstract void Izvrsi();
    }
}
