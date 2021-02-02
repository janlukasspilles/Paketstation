//Autor:        Jan-Lukas Spilles
//Klasse:       IA119
//Datei:        Paketfach.cs
//Datum:        19.11.2020
//Beschreibung: Repräsentiert ein Paketfach
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
        public Paketfach(Paket p)
        {
            Paket = p;
        }
        #endregion
        #region Methods
        public Paket PaketAusgeben()
        {
            Paket p = Paket;
            Paket = null;
            return p;
        }

        public void PaketEinfuegen(Paket paket)
        {
            Paket = paket;
        }

        public void Oeffnen()
        {
            Status = true;
        }

        public void Schliessen()
        {
            Status = false;
        }
        #endregion
    }
}
