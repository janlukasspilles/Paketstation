using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paketstation
{
    public class KeinFreiesSchliessfachException : Exception
    {
        public KeinFreiesSchliessfachException()
        {

        }
        public KeinFreiesSchliessfachException(string message) : base(message)
        {

        }
        public KeinFreiesSchliessfachException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
