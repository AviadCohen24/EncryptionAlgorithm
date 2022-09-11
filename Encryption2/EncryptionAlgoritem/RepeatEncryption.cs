using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption2
{
    public class RepeatEncryption : IEncryptionAlgoritem
    {
        public static IEncryptionAlgoritem AlgorithmType;
        public static int Iteration;
        public RepeatEncryption() { }

        public RepeatEncryption(IEncryptionAlgoritem encryptionAlgoritem)
        {
            AlgorithmType = encryptionAlgoritem;
        }

        public int KeyStrength
        {
            get { return KeyManager.FindStregthKey()* Iteration; }
        }

        public string Encrypt(string lines, int[] key)
        {
            return AlgorithmType.Encrypt(lines, key);
        }

        public string Decrypt(string lines, int[] key)
        {
            return AlgorithmType.Decrypt(lines, key);
        }

    }
}
