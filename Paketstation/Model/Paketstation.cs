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
        private Schliessfach[] _schliessfaecher;
        #endregion
        #region Properties
        public Schliessfach[] Schliessfaecher { get => _schliessfaecher; set => _schliessfaecher = value; }
        #endregion
        #region Constructors
        public Paketstation()
        {
            Schliessfaecher = new Schliessfach[9];
        }
        #endregion
        #region Methods

        public int PaketEinliefern(Paket paket)
        {
            int pos = GetFreiesSchliessfach();
            if (pos != -1)
            {
                Schliessfaecher[pos].Paket = paket;
            }
            return pos;
        }

        public Paket PaketHolen(string paketnummer)
        {
            int pos = GetSchliessfachByPaketnummer(paketnummer);
            if(pos != -1)
            {
                return Schliessfaecher[pos].Oeffnen();
            }
            return null;
        }

        private int GetSchliessfachByPaketnummer(string paketnummer)
        {
            for (int i = 0; i < Schliessfaecher.Length; i++)
            {
                if (Schliessfaecher[i].Paket.Paketnummer == paketnummer)
                {
                    return i;
                }
            }
            return -1;
        }

        private int GetFreiesSchliessfach()
        {
            for (int i = 0; i < Schliessfaecher.Length; i++)
            {
                if (Schliessfaecher[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion
    }
}
