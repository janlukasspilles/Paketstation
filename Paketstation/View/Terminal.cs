using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paketstation
{
    public class Terminal
    {
        #region Attributes
        private string _text;
        #endregion
        #region Properties
        public string Text { get => _text; set => _text = value; }
        #endregion
        #region Constructors
        public Terminal()
        {
        }
        #endregion
        #region Methods 
        public void TextAusgeben()
        {
            Console.Write(Text);
        }
        public ConsoleKeyInfo TextEinlesen()
        {
            return Console.ReadKey(true);
        }
        #endregion
    }
}
