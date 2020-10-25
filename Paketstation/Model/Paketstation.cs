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
        }
        #endregion
        #region Methods
        public Paketschein PaketAnnehmen(Paket paket, Guid kundennummer)
        {
            int pos = GetFreiesSchliessfach();
            if (pos != -1)
            {
                Faecher[pos].Paket = paket;
                return new Paketschein(kundennummer, paket.Paketnummer);
            }
            else
            {
                return null;
            }            
        }

        public Paket PaketAusgeben(Paketschein paketschein)
        {
            int pos = PaketFinden(paketschein.Paketnummer);
            if(pos != -1)
            {
                return Faecher[pos].PaketAusgeben();
            }
            return null;
        }

        private int PaketFinden(Guid paketnummer)
        {
            for (int i = 0; i < Faecher.Length; i++)
            {
                if (Faecher[i].Paket.Paketnummer.ToString() == paketnummer.ToString())
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
                if (Faecher[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion
    }
}
