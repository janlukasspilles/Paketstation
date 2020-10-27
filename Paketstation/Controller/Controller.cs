using Paketstation.Model;
using Paketstation.View;
using System.Linq;

namespace Paketstation
{
    public class Controller
    {
        #region Attributes
        private Paketstation _station;
        private Kunde[] _kunden;
        private UserInterface _IO;
        #endregion
        #region Properties
        public Paketstation Station { get => _station; set => _station = value; }
        public Kunde[] Kunden { get => _kunden; set => _kunden = value; }
        public UserInterface IO { get => _IO; set => _IO = value; }

        #endregion
        #region Constructors
        public Controller()
        {
            Station = new Paketstation();
            Kunden = new Kunde[4];
            Kunden[0] = new Kunde("Hans", "Rheinbach");
            Kunden[1] = new Kunde("Peter", "Meckenheim");
            Kunden[2] = new Kunde("Maria", "Bonn");
            Kunden[3] = new Kunde("Eva", "Köln");
            IO = new UserInterface();

        }
        #endregion
        #region Methods
        public void run()
        {
            bool isActive = true;
            do
            {
                int selectedMainMenuPoint = IO.SelectableMenu(string.Join(";", Kunden.Select(x => x.Name)) + ";Splashinfo;" + "Schließen", "Wählen Sie einen Kunden aus:");
                if (selectedMainMenuPoint > Kunden.Length)
                {
                    if (selectedMainMenuPoint == Kunden.Length)
                    {
                        IO.Splashinfo();
                    }
                    else if (selectedMainMenuPoint == Kunden.Length + 1)
                    {
                        isActive = false;
                    }
                }
                else
                {
                    bool KundeIstAusgewaehlt = true;
                    do
                    {
                        int ausgewaehlterGeschaeftsprozess = IO.SelectableMenu("Paket einliefern;Paket abholen;Eigene Pakete Listen;Paket öffnen;Zurück", "Wählen Sie eine Operation aus:");
                        switch (ausgewaehlterGeschaeftsprozess)
                        {
                            case 0:
                                KundeLiefertPaketEin(Kunden[ausgewaehlterGeschaeftsprozess]);
                                break;
                            case 1:
                                KundeHoltPaketAb(Kunden[ausgewaehlterGeschaeftsprozess]);
                                break;
                            case 2:
                                KundeListeEigenePaket(Kunden[ausgewaehlterGeschaeftsprozess]);
                                break;
                            case 3:
                                KundePaketOeffnen(Kunden[ausgewaehlterGeschaeftsprozess]);
                                break;
                            default:
                                KundeIstAusgewaehlt = false;
                                break;
                        }
                    } while (KundeIstAusgewaehlt);
                }
            } while (isActive);
        }

        private void KundeLiefertPaketEin(Kunde k)
        {
            k.Paket1 = IO.PaketEinliefern(k.Name);
            Station.PaketAnnehmen(k.PaketEinliefern());
        }

        private void KundeHoltPaketAb(Kunde k)
        {

            k.PaketAbholen(Station.PaketAusgeben(k.Kundennummer));
        }
        private void KundeListeEigenePaket(Kunde k)
        {
            IO.PaketeListen(Station.PaketeListen(k.Name));
        }
        private void KundePaketOeffnen(Kunde k)
        {
            if (k.Paket1 != null)
                k.PaketOeffnen();
            else
                IO.MeldungKeinPaket();
            
        }
        #endregion
    }
}
