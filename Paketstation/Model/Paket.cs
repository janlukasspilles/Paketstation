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
        #endregion
        #region Properties
        public Guid Paketnummer { get => _paketnummer; set => _paketnummer=value; }
        #endregion
        #region Constructors
        public Paket()
        {
            Paketnummer = new Guid();
        }
        #endregion
        #region Methods
        #endregion
    }
}
