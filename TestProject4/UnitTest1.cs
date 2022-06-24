using System;
using Xunit;
using ZooloskiVrt.Common.Domen;


namespace TestProject4
{
    public class PaketTests
    {
        private readonly Paket p;

        public PaketTests()
        {
            p = new Paket();
        }

        [Fact]
        public void SetPaketId_PositiveInt_Theory()
        {
            p.SetIdPaketa(2);
            Assert.Equal(2, p.GetIdPaketa());
        }
    }
}
