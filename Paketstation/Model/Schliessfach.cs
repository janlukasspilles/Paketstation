using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paketstation
{
    public class Schliessfach
    {
        #region Attributes
        private Paket _paket;
        #endregion
        #region Properties
        public Paket Paket { get => _paket; set => _paket = value; }
        #endregion
        #region Constructors
        public Schliessfach()
        {
            Paket = null;
        }
        #endregion
        #region Methods
        public Paket Oeffnen()
        {
            Paket p = Paket;
            Paket = null;
            return p;
        }
        #endregion
    }
}
