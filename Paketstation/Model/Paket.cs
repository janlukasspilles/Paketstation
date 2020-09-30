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
        private string _empfaenger;
        private string _absender;
        #endregion
        #region Properties
        public string Paketnummer { get => _paketnummer; set => _paketnummer=value; }
        public string Inhalt { get => _inhalt; set => _inhalt = value; }
        public string Empfaenger { get => _empfaenger; set => _empfaenger = value; }
        public string Absender { get => _absender; set => _absender = value; }
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
        
        #endregion
    }
}
