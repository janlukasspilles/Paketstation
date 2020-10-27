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
        private Schliessfach[] _faecher;
        private Terminal _userInterface;
        private string _standort;
        private Guid _id;
        private int _globalIdCounter;
        #endregion
        #region Properties
        public Schliessfach[] Faecher { get => _faecher; set => _faecher = value; }
        public Terminal UserInterface { get => _userInterface; set => _userInterface = value; }
        public string Standort { get => _standort; set => _standort = value; }
        public Guid Id { get => _id; set => _id = value; }
        #endregion
        #region Constructors
        public Paketstation()
        {
            Faecher = new Schliessfach[9];
            for (int zaehler = 0; zaehler < Faecher.Length; zaehler++)
            {
                Faecher[zaehler] = new Schliessfach();
            }
            _globalIdCounter = 0;
        }
        #endregion
        #region Methods
        public void PaketAnnehmen(Paket paket)
        {
            int pos = GetFreiesSchliessfach();
            if (pos != -1)
            {
                paket.Paketnummer = _globalIdCounter++;
                Faecher[pos].Paket = paket;
            }
            else
            {
                //Exception?
            }
        }

        public Paket PaketAusgeben(int paketnummer)
        {
            int pos = PaketFinden(paketnummer);
            if (pos != -1)
            {
                return Faecher[pos].PaketAusgeben();
            }
            return null;
        }

        public int[] PaketeListen(string kundenname)
        {
            int[] res = new int[AnzahlPaketeFuerKunden(kundenname)];
            int zaehler = 0;
            for (int i = 0; i < Faecher.Length; i++)
            {
                if (Faecher[i].Paket != null && Faecher[i].Paket.Empfaenger == kundenname)
                {
                    //Geht das???
                    res[zaehler++] = Faecher[i].Paket.Paketnummer;
                }
            }
            return res;
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
            return -1;
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
