using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooloskiVrt.Common.Domen;
using ZooloskiVrt.Klijent.Forme.UserControls.Paketi;

namespace ZooloskiVrt.Klijent.Forme.GUIController.Paketi
{
    public class PaketPosetilacKontroler
    {
        public Paket Paket { get; set; }
        public UCPaketPosetioci uc;

        public PaketPosetilacKontroler(UCPaketPosetioci ucPP,Paket paket)
        {
            this.Paket = paket;
            this.uc = ucPP;
        }

        public void Inicijalizuj()
        {
            uc.Lbl2.Text = Paket.NazivPaketa;
            Paket.JoinUslov = "join Prijava on (Posetilac.IdPosetioca=Prijava.IdPosetioca)";
            Paket.Uslov = $"where IdPaketa={Paket.IdPaketa}";
            uc.DgvPP.DataSource = Komunikacija.Instance.ZahtevajIVratiRezultat<List<Posetilac>>(Common.Komunikacija.Operacija.VratiSvePosetioceZaPaket,Paket);
        }
    }
}
