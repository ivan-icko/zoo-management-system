using Xunit;
using System;
using ZooloskiVrt.Common.Domen;
using Moq;
using Autofac.Extras.Moq;
using System.Data.SqlClient;
using ZooloskiVrt.Server.BrokerBazePodataka;

namespace ZooloskiVrt.Common.Domen.Tests
{
    public class IDomenskiObjekatTests
    {
        protected IDomenskiObjekat ido;
        protected IDomenskiObjekat rez;

        [Fact]
        public IDomenskiObjekat ProcitajRedTest()
        {

               SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ZooloskiVrtTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            if (ido != null)
            {
                Broker b = new Broker(connection);
                b.OtvoriKonekciju();
                b.ZapocniTransakciju();
                SqlCommand c = b.KreirajKomandu();


                c.CommandText = $"SELECT * FROM {ido.NazivTabele}";

                using (SqlDataReader reader = c.ExecuteReader())
                {
                    int i = 1;
                    while (i > 0 && reader.Read())
                    {
                        rez = ido.ProcitajRed(reader);
                        i--;
                    }
                }
                b.ZatvoriKonekciju();
            }

                Assert.Equal(ido, rez);

            return rez;
        }
    }
}
