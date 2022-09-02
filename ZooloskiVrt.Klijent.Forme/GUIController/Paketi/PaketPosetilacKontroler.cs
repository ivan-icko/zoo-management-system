using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooloskiVrt.Common.Domen;
using ZooloskiVrt.Klijent.Forme.UserControls.Paketi;

namespace ZooloskiVrt.Klijent.Forme.GUIController.Paketi
{
    public class PaketPosetilacKontroler
    {
        public Paket Paket { get; set; }
        public UCPaketPosetioci uc;
        private List<Posetilac> source;

        public PaketPosetilacKontroler(UCPaketPosetioci ucPP,Paket paket, List<Posetilac> source)
        {
            this.Paket = paket;
            this.uc = ucPP;
            this.source = source;
        }

        public void Inicijalizuj()
        {
            uc.Lbl2.Text = Paket.NazivPaketa;
            uc.DgvPP.DataSource = source;
           
        }
    }
}
