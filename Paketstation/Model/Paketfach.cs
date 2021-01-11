using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paketstation
{
    public class Paketfach
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
        public Paketfach()
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

        //Eigentlich nur der Setter wtf?
        public void PaketEinfuegen(Paket paket)
        {
            Paket = paket;
        }

        public void Oeffnen()
        {
            //brr brr öffnen
        }

        public void Schliessen()
        {
            //brr brr schliessen
        }
        #endregion
    }
}
