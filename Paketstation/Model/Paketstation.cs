//Autor:        Jan-Lukas Spilles
//Klasse:       IA119
//Datei:        Paketstation.cs
//Datum:        19.11.2020
//Beschreibung: Repräsentiert eine Paketstation
using Paketstation.Model;
using System;

namespace Paketstation
{
    public class Paketstation
    {
        #region Attributes
        private Paketfach[] _faecher;
        private UserInterface _terminal;
        private string _standort;
        #endregion
        #region Properties
        public Paketfach[] Faecher { get => _faecher; set => _faecher = value; }
        public UserInterface Terminal { get => _terminal; set => _terminal = value; }
        public string Standort { get => _standort; set => _standort = value; }
        #endregion
        #region Constructors
        public Paketstation()
        {
            Terminal = new UserInterface(true);
            Faecher = new Paketfach[9];
            for (int zaehler = 0; zaehler < Faecher.Length; zaehler++)
            {
                Faecher[zaehler] = new Paketfach();
            }
        }

        public Paketstation(string standort)
        {
            Terminal = new UserInterface(true);
            Faecher = new Paketfach[9];
            for (int zaehler = 0; zaehler < Faecher.Length; zaehler++)
            {
                Faecher[zaehler] = new Paketfach();
            }
            Standort = standort;
        }
        #endregion
        #region Methods
        public int ShowInitMenu()
        {
            return Terminal.SelectableMenu("Paket abgeben;Paket abholen;Pakete listen;Beenden", "Willkommen!\r\nBitte wählen Sie eine Aktion aus!");
        }

        public string KundeAuthentifizieren()
        {
            return Terminal.Kundenauthentifizierung();
        }
        public void PaketAnnehmen(Paket paket)
        {
            
            int pos = GetFreiesSchliessfach();
            if (pos != -1)
            {
                string s = Terminal.PaketAddressieren();
                paket.Empfaenger = s;
                Faecher[pos].Oeffnen();
                Terminal.Text = "Schließfach öffnet sich.";
                Terminal.TextAusgeben();
                Faecher[pos].PaketEinfuegen(paket);
                Faecher[pos].Schliessen();
                Terminal.Text = "Schließfach schließt sich.";
                Terminal.TextAusgeben();
                Terminal.Text = "Paket erfolgreich abgegeben!";
                Terminal.TextAusgeben();
            }
            else
            {
                Terminal.Text = "Es steht derzeit kein freies Paketfach zur Verfügung. Bitte versuchen Sie es zu einem späteren Zeitpunkt erneut.";
                Terminal.TextAusgeben();
            }
        }

        public int AbfragePaketnummer()
        {
            return Terminal.AbfragePaketnummer();
        }

        public Paket PaketAusgeben(int paketnummer)
        {
            try
            {
                Paket tmp = Faecher[PaketFinden(paketnummer)].PaketAusgeben();
                if(tmp != null)
                {
                    Terminal.Text = $"Paket mit der Nummer: {paketnummer} wurde erfolgreich ausgegeben.";
                    Terminal.TextAusgeben();
                }
                return tmp;
            }
            catch (Exception e)
            {
                Terminal.ShowExceptionText(e.Message);
            }
            return null;
        }

        public void PaketeListen(string kundenname)
        {
            int[] res = new int[AnzahlPaketeFuerKunden(kundenname)];
            int pos = 0;
            for (int i = 0; i < Faecher.Length; i++)
            {
                if (Faecher[i].Paket != null && Faecher[i].Paket.Empfaenger == kundenname)
                {
                    res[pos++] = Faecher[i].Paket.Paketnummer;
                }
            }
            Terminal.PaketeListen(res);
        }

        private int AnzahlPaketeFuerKunden(string kundenname)
        {
            int res = 0;
            for (int i = 0; i < Faecher.Length; i++)
            {
                if (Faecher[i].Paket != null && Faecher[i].Paket.Empfaenger == kundenname)
                {
                    res++;
                }
            }
            return res;
        }

        private int PaketFinden(int paketnummer)
        {
            for (int i = 0; i < Faecher.Length; i++)
            {
                if (Faecher[i].Paket != null && Faecher[i].Paket.Paketnummer.ToString() == paketnummer.ToString())
                {
                    return i;
                }
            }
            throw new Exception($"Es gibt kein Paket mit der Paketnummer: {paketnummer}");
        }

        private int GetFreiesSchliessfach()
        {
            for (int i = 0; i < Faecher.Length; i++)
            {
                if (Faecher[i].Paket == null)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion
    }
}
