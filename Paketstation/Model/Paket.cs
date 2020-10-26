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
        private Guid _paketnummer;
        private string _inhalt;
        private int _gewicht;
        private string _groesse;
        private string _empfaenger;
        private string _absender;
        #endregion
        #region Properties
        public Guid Paketnummer { get => _paketnummer; set => _paketnummer=value; }
        public string Inhalt { get => _inhalt; set => _inhalt = value; }
        public int Gewicht { get => Gewicht; set => Gewicht = value; }
        public string Groesse { get => _groesse; set => _groesse = value; }
        public string Empfaenger { get => _empfaenger; set => _empfaenger = value; }
        public string Absender { get => _absender; set => _absender = value; }
        #endregion
        #region Constructors
        public Paket()
        {
            Paketnummer = Guid.NewGuid();
        }

        public Paket(string empfaenger, string absender)
        {
            Paketnummer = Guid.NewGuid();
            Empfaenger = empfaenger;
            Absender = absender;
        }

        public Paket(string empfaenger, string absender, string inhalt)
        {
            Paketnummer = Guid.NewGuid();
            Empfaenger = empfaenger;
            Absender = absender;
            Inhalt = inhalt;
        }        
        #endregion
        #region Methods
        #endregion
    }
}
