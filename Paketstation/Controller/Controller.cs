using Paketstation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Paketstation.Controller
{
    public class Controller
    {
        #region Attributes
        private Paketstation _station;
        private Kunde _kunde;
        #endregion
        #region Properties
        public Paketstation Station { get => _station; set => _station = value; }
        public Kunde Kunde { get => _kunde; set => _kunde = value; }

        #endregion
        #region Constructors
        public Controller()
        {
            Station = new Paketstation();
            Kunde = new Kunde();
        }
        #endregion
        #region Methods
        public void run()
        {

        }

        private void KundeLiefertPaketEin()
        {
            Kunde.Paketscheine.Enqueue(Station.PaketAnnehmen(Kunde.PaketEinliefern(), Kunde.Kundennummer));
        }

        private void KundeHoltPaketAb()
        {
            Kunde.PaketAbholen(Station.PaketAusgeben(Kunde.Paketscheine.Dequeue()));
        }
        private void KundeListeEigenePakete()
        {
            //wtf
        }
        #endregion
    }
}
