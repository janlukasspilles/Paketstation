using Paketstation.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Paketstation
{
    public class Controller
    {
        #region Attributes
        private Paketstation _station;
        private List<Kunde> _kunden;
        #endregion
        #region Properties
        public Paketstation Station { get => _station; set => _station = value; }
        public List<Kunde> Kunden { get => _kunden; set => _kunden = value; }

        #endregion
        #region Constructors
        public Controller()
        {
            Station = new Paketstation();
            Kunden = new List<Kunde>();
            TestDaten();
        }
        #endregion
        #region Methods
        public void TestDaten()
        {
            Kunden.Add(new Kunde("Testkunde", "Steinschönauer Str. 6", 5));
            Station.Faecher[3].Paket = new Paket("Testkunde", "kunde1");
            Station.Faecher[4].Paket = new Paket("Testkunde", "kunde1");
            Station.Faecher[5].Paket = new Paket("Testkunde", "kunde1");
        }
        public void run()
        {
            bool isActive = true;
            do
            {
                int auswahl = Station.ShowInitMenu();
                switch (auswahl)
                {
                    //Paket annehmen
                    case 0:
                        KundeLiefertPaketEin();
                        break;
                    //Paket abholen
                    case 1:
                        KundeHoltPaketAb();
                        break;
                    //Pakete Listen
                    case 2:
                        KundeListeEigenePaket();
                        break;
                    case 3:
                        isActive = false;
                        break;
                    default: //Nichts
                        break;
                }
            } while (isActive);
        }

        private void KundeLiefertPaketEin()
        {
            string kundennummer = Station.KundeAuthentifizieren();
            Kunde tmp = Kunden.Find(x => x.Kundennummer == Convert.ToInt32(kundennummer));
            if (tmp == null)
            {
                tmp = Station.AnmeldungNeuerKunde();
                Kunden.Add(tmp);
            }
            Station.PaketAnnehmen(tmp.Paket1);
        }

        private void KundeHoltPaketAb()
        {
            string kundennummer = Station.KundeAuthentifizieren();
            Kunde tmp = Kunden.Find(x => x.Kundennummer == Convert.ToInt32(kundennummer));
            if (tmp != null)
            {

            }
        }
        private void KundeListeEigenePaket()
        {
            string kundennummer = Station.KundeAuthentifizieren();
            Kunde tmp = Kunden.Find(x => x.Kundennummer == Convert.ToInt32(kundennummer));
            if (tmp != null)
            {
                Station.PaketeListen(tmp.Name);
            }
        }
        #endregion
    }
}
