﻿using System;
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
        private Queue<Paketschein> _paketscheine;
        #endregion
        #region Properties
        public Paket Paket1 { get => _paket1; set => _paket1 = value; }
        public string Name { get => _name; set => _name = value; }
        public string Adresse { get => _adresse; set => _adresse = value; }
        public Guid Kundennummer { get => _kundennummer; set => _kundennummer = value; }
        public Queue<Paketschein> Paketscheine { get => _paketscheine; set => _paketscheine = value; }
        #endregion
        #region Constructors
        public Kunde()
        {
            Kundennummer = Guid.NewGuid();
            Paket1 = new Paket();
            Paketscheine = new Queue<Paketschein>();
        }
        public Kunde(string name, string adresse)
        {
            Name = name;
            Adresse = adresse;
            Kundennummer = Guid.NewGuid();
            Paket1 = new Paket();
            Paketscheine = new Queue<Paketschein>();
        }
        public Kunde(Paket p, string name, string adresse)
        {
            Name = name;
            Adresse = adresse;
            Kundennummer = Guid.NewGuid();
            Paket1 = p;
            Paketscheine = new Queue<Paketschein>();
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
        #endregion
    }
}