using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Encryption2
{
    public class DoubleEncryption<TAlgorithm> : RepeatEncryption where TAlgorithm : IEncryptionAlgoritem, new()
    {      
        public DoubleEncryption() : base(new TAlgorithm())  
        {

        }
    }
}
