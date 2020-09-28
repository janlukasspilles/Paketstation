using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paketstation
{
    public class Paket
    {
        #region Attributes
        private string _paketnummer;
        private string _inhalt;
        #endregion
        #region Properties
        public string Paketnummer { get => _paketnummer; set => _paketnummer=value; }
        public string Inhalt { get => _inhalt; set => _inhalt = value; }
        #endregion
        #region Constructors
        public Paket()
        {
            Paketnummer = new Guid().ToString();
        }

        public Paket(string inhalt)
        {
            Paketnummer = new Guid().ToString();
            Inhalt = inhalt;
        }
        #endregion
        #region Methods
        public void Zuweisen(Paket paket)
        {
            Paketnummer = paket.Paketnummer;
            Inhalt = paket.Inhalt;
        }
        #endregion
    }
}
