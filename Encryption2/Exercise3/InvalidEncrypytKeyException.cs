using Encryption2.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption2
{
    class InvalidEncrypytKeyException: Exception
    {
        public InvalidEncrypytKeyException(string msg):base(msg)
        {                       
        }
    }
}
