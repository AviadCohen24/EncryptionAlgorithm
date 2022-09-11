using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption2
{
    public interface IEncryptionAlgoritem
    {
        string Encrypt(string lines, int[] key);
        string Decrypt(string lines, int[] key);
        int KeyStrength { get; }
    }
}
