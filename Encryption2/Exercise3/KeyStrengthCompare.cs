using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption2
{
    public class KeyStrengthCompare : IComparer<IEncryptionAlgoritem>
    {
        public int Compare(IEncryptionAlgoritem x, IEncryptionAlgoritem y)
        {
            if (x.KeyStrength > y.KeyStrength) return 1;
            else if (x.KeyStrength < y.KeyStrength) return -1;
            else return 0;
        }
    }
}
