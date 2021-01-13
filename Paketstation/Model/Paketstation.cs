using Paketstation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paketstation
{
    public class Paketstation
    {
        #region Attributes
        private Paketfach[] _faecher;
        private UserInterface _terminal;
        private string _standort;
        private Guid _id;
        #endregion
        #region Properties
        public Paketfach[] Faecher { get => _faecher; set => _faecher = value; }
        public UserInterface Terminal { get => _terminal; set => _terminal = value; }
        public string Standort { get => _standort; set => _standort = value; }
        public Guid Id { get => _id; set => _id = value; }
        #endregion
        #region Constructors
        public Paketstation()
        {
            Terminal = new UserInterface();
            Faecher = new Paketfach[9];
            for (int zaehler = 0; zaehler < Faecher.Length; zaehler++)
            {
                Faecher[zaehler] = new Paketfach();
            }
        }
        #endregion
        #region Methods
        public int ShowInitMenu()
        {
            return Terminal.SelectableMenu("Paket abgeben;Paket abholen;Pakete listen;Beenden", "Willkommen!\r\nBitte wählen Sie eine Aktion aus!");
        }

        public Kunde AnmeldungNeuerKunde()
        {
            return Terminal.NeuerKunde();
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
                Faecher[pos].Oeffnen();
                Faecher[pos].PaketEinfuegen(paket);
                Faecher[pos].Schliessen();
            }
            else
            {
                Terminal.MeldungKeinFreiesPaketfach();
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
                return Faecher[PaketFinden(paketnummer)].PaketAusgeben();
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
