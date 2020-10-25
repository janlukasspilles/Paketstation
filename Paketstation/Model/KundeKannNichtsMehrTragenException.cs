using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paketstation.Model
{
    public class KundeKannNichtsMehrTragenException : Exception
    {
        public KundeKannNichtsMehrTragenException()
        {

        }
        public KundeKannNichtsMehrTragenException(string message) : base(message)
        {

        }
        public KundeKannNichtsMehrTragenException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
