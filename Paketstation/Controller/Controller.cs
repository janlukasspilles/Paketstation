//Autor:        Jan-Lukas Spilles
//Klasse:       IA119
//Datei:        Controller.cs
//Datum:        19.11.2020
//Beschreibung: Kümmert sich um den Programmablauf
using Paketstation.Model;
using System;
using System.Collections.Generic;

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
        }
        public Controller(bool withTestdata)
        {
            Station = new Paketstation();
            Kunden = new List<Kunde>();
            if (withTestdata)
            {
                TestDaten();
            }
            else
            {
                //Nichts
            }            
        }
        #endregion
        #region Methods
        private void TestDaten()
        {
            Kunden.Add(new Kunde("Testkunde", "Steinschönauer Str. 6", 5));
            Kunden.Add(new Kunde("Testkunde2", "Gablonzer Str. 13", 1));
            Random r = new Random();
            Station.Faecher[3].Paket = new Paket("Testkunde", "kunde1", r.Next(0, 100));
            Station.Faecher[4].Paket = new Paket("Testkunde", "kunde1", r.Next(0, 100));
            Station.Faecher[5].Paket = new Paket("Testkunde", "kunde1", r.Next(0, 100));
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
            if (tmp != null)
            {
                Station.PaketAnnehmen(tmp.PaketEinliefern());
            }
            else
            {
                //Nichts
            }
        }

        private void KundeHoltPaketAb()
        {
            string kundennummer = Station.KundeAuthentifizieren();
            int kunde = Kunden.IndexOf(Kunden.Find(x => x.Kundennummer == Convert.ToInt32(kundennummer)));
            if (kunde != -1)
            {
                Kunden[kunde].PaketAbholen(Station.PaketAusgeben(Station.AbfragePaketnummer()));
            }
            else
            {
                //Nichts
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
            else
            {
                //Nichts
            }
        }
        #endregion
    }
}
