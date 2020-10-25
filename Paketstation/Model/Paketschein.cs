using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paketstation
{
    public class Paketschein
    {
        #region Attributes
        private Guid _paketnummer;
        private Guid _kundennummer;
        #endregion
        #region Properties
        public Guid Paketnummer { get => _paketnummer; set => _paketnummer = value; }
        public Guid Kundennummer { get => _kundennummer; set => _kundennummer = value; }
        #endregion
        #region Constructors
        public Paketschein()
        {
            Paketnummer = Guid.NewGuid();
            Kundennummer = Guid.NewGuid();
        }

        public Paketschein(Guid kundennummer, Guid paketnummer)
        {
            Paketnummer = paketnummer;
            Kundennummer = kundennummer;
        }
        #endregion
        #region Methods
        #endregion
    }
}
