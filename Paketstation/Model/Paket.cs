﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paketstation
{
    public class Paket
    {
        #region Attributes
        private int _paketnummer;
        private string _inhalt;
        private string _groesse;
        private string _empfaenger;
        private string _absender;
        #endregion
        #region Properties
        public int Paketnummer { get => _paketnummer; set => _paketnummer=value; }
        public string Inhalt { get => _inhalt; set => _inhalt = value; }
        public string Groesse { get => _groesse; set => _groesse = value; }
        public string Empfaenger { get => _empfaenger; set => _empfaenger = value; }
        public string Absender { get => _absender; set => _absender = value; }
        #endregion
        #region Constructors
        public Paket()
        {
            
        }

        public Paket(string empfaenger, string absender)
        {
            Empfaenger = empfaenger;
            Absender = absender;
        }

        public Paket(string empfaenger, string absender, string inhalt)
        {
            Empfaenger = empfaenger;
            Absender = absender;
            Inhalt = inhalt;
        }        
        #endregion
        #region Methods
        #endregion
    }
}
