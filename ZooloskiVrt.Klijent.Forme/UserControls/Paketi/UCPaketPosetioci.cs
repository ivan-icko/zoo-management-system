using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZooloskiVrt.Common.Domen;
using ZooloskiVrt.Klijent.Forme.GUIController.Paketi;

namespace ZooloskiVrt.Klijent.Forme.UserControls.Paketi
{
    public partial class UCPaketPosetioci : UserControl
    {
        PaketPosetilacKontroler kontroler;


        public UCPaketPosetioci(Paket paket, List<Posetilac> source)
        {
            InitializeComponent();
            kontroler = new PaketPosetilacKontroler(this,paket,source);
            kontroler.Inicijalizuj();
        }
    }
}
