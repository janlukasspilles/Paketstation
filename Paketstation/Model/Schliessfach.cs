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
        private bool _status;
        #endregion
        #region Properties
        public Paket Paket { get => _paket; set => _paket = value; }
        public bool Status { get => _status; set => _status = value; }
        #endregion
        #region Constructors
        public Schliessfach()
        {
            Paket = null;
        }
        #endregion
        #region Methods
        public Paket PaketAusgeben()
        {
            Paket p = Paket;
            Paket = null;
            return p;
        }
        #endregion
    }
}
