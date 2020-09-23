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
        public Paket SchliessfachOeffnen(Guid paketnummer)
        {

            return Schliessfaecher.First(x => x.Paket.Paketnummer.CompareTo(paketnummer) == 0).Paket;
        }

        public bool SchliessfachSchliessen(Paket paket)
        {
            for (int i = 0; i < Schliessfaecher.Length; i++)
            {
                if (Schliessfaecher[i].Paket.Paketnummer.CompareTo(paketnummer) == 0)
                {
                    return i;
                }
            }
            return -1;
        }



        private int FindeSchliessfachMitPaket(Guid paketnummer)
        {
            for (int i = 0; i < Schliessfaecher.Length; i++)
            {
                if (Schliessfaecher[i].Paket.Paketnummer.CompareTo(paketnummer) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        private int SchliessfachFrei()
        {
            for (int i = 0; i < Schliessfaecher.Length; i++)
            {
                if(Schliessfaecher[i] == null)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion
    }
}
