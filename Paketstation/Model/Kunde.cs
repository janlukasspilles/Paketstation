using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paketstation.Model
{
    public class Kunde
    {
        #region Attributes
        private Paket _paket1;
        private string _name;
        private string _adresse;
        private Guid _kundennummer;
        #endregion
        #region Properties
        public Paket Paket1 { get => _paket1; set => _paket1 = value; }
        public string Name { get => _name; set => _name = value; }
        public string Adresse { get => _adresse; set => _adresse = value; }
        public Guid Kundennummer { get => _kundennummer; set => _kundennummer = value; }
        #endregion
        #region Constructors
        public Kunde()
        {
            Kundennummer = Guid.NewGuid();
        }
        public Kunde(string name, string adresse)
        {
            Name = name;
            Adresse = adresse;
            Kundennummer = Guid.NewGuid();
        }
        public Kunde(Paket p, string name, string adresse)
        {
            Name = name;
            Adresse = adresse;
            Kundennummer = Guid.NewGuid();
            Paket1 = p;
        }
        #endregion
        #region Methods
        public Paket PaketEinliefern()
        {
            Paket res = Paket1;
            Paket1 = null;
            return res;
        }
        public void PaketAbholen(Paket p)
        {
            if (Paket1 != null)
                throw new KundeKannNichtsMehrTragenException();
            Paket1 = p;
        }
        public void PaketVorbereiten(string inhalt, string empfaenger)
        {
            if(Paket1 == null)
            {
                Paket1 = new Paket(empfaenger, Name, inhalt);
            }
        }
        public Paket PaketOeffnen()
        {
            Paket res = Paket1;
            Paket1 = null;
            return res;
        }
        #endregion
    }
}
