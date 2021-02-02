//Autor:        Jan-Lukas Spilles
//Klasse:       IA119
//Datei:        Paket.cs
//Datum:        19.11.2020
//Beschreibung: Repräsentiert ein Paket
using System;

namespace Paketstation
{
    public class Paket
    {
        #region Attributes
        private int _paketnummer;
        private string _groesse;
        private string _empfaenger;
        private string _absender;
        #endregion
        #region Properties
        public int Paketnummer { get => _paketnummer; set => _paketnummer = value; }
        public string Groesse { get => _groesse; set => _groesse = value; }
        public string Empfaenger { get => _empfaenger; set => _empfaenger = value; }
        public string Absender { get => _absender; set => _absender = value; }
        #endregion
        #region Constructors
        public Paket()
        {

        }

        public Paket(string empfaenger, string absender, int paketnummer)
        {
            Empfaenger = empfaenger;
            Absender = absender;
            Paketnummer = paketnummer;
        }

        public Paket(string empfaenger, string absender)
        {
            Empfaenger = empfaenger;
            Absender = absender;
            Paketnummer = new Random().Next();
        }
        #endregion
        #region Methods
        public override string ToString()
        {
            return $"Absender: {this.Absender}\r\nEmpfänger: {this.Empfaenger}\r\nPaketnummer: {this.Paketnummer}";
        }
        #endregion
    }
}
