using Encryption2.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption2
{
    public abstract class EncryptionAlgoritem : IEncryptionAlgoritem
    {
        public virtual char EncryptOp(char myChar, int key)
        {
            throw new NotImplementedException();
        }

        public virtual char DecryptOp(char myChar, int key)
        {
            throw new NotImplementedException();
        }

        public virtual int KeyStrength
        {
            get { throw new NotImplementedException(); }
        }

        public string Encrypt(string lines, int[] key)
        {
            var finelString = string.Empty;
            for (int i = 0; i < key.Length; i++)
            {
                var tempString = string.Empty;
                foreach (char currChar in lines)
                {
                    tempString += EncryptOp(currChar, key[i]);
                    finelString = tempString;
                }
            }
            return finelString;
        }

        public string Decrypt(string lines, int[] key)
        {
            var finelString = string.Empty;
            for (int i = 0; i < key.Length; i++)
            {
                var tempString = string.Empty;
                foreach (char currChar in lines)
                {
                    tempString += DecryptOp(currChar, key[i]);
                    finelString = tempString;
                }
            }
            return finelString;
        }    
    }
}
