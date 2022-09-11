using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Encryption2
{
    public class ShiftUpEncryption : EncryptionAlgoritem,IComparable
    {
        public override char EncryptOp(char myChar, int key)
        {          
            return (char)(myChar + key);
        }

        public override char DecryptOp(char myChar, int key)
        {
            return (char)(myChar - key);
        }

        public override int KeyStrength
        {
            get { return KeyManager.FindStregthKey(); }
        }

        public int CompareTo(object obj)
        {
            if (obj is IEncryptionAlgoritem)
                 return KeyStrength.CompareTo((obj as IEncryptionAlgoritem).KeyStrength); 
           throw new Exception();
        }
        public override bool Equals(object obj)
        {
            return CompareTo(obj) == 0;
        }
        public override int GetHashCode()
        {
            return KeyStrength.GetHashCode();
        }
       
    }
}

