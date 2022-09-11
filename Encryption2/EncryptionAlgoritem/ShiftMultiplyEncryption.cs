using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption2
{
    public class ShiftMultiplyEncryption : EncryptionAlgoritem
    {      
        public override char EncryptOp(char myChar, int key)
        {
            return (char)(myChar * key);
        }

        public override char DecryptOp(char myChar, int key)
        {
            return (char)(myChar / key);
        }
        public override int KeyStrength
        {
            get { return KeyManager.FindStregthKey(); }
        }
    }
}
