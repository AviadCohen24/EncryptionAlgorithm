using Encryption2.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption2
{
    public class KeyManager
    {
        Validator validator = new Validator();
        public const int minRange = 2, maxRange = 8;
        public int[] GetValidKey()
        {
            InvalidEncrypytKeyException e = new InvalidEncrypytKeyException("invalid key, try again.");
            string str = FileIO.Read(validator.GetValidFilePath("Enter your key file location"));
            int[] keys = StringToArrey(str);
            for (int i = 0; i < keys.Length; i++)
            {
                while (keys[i] < minRange || keys[i] > maxRange)
                {
                    ConsoleIO.Write(e.Message);
                    GetValidKey();
                }
            }
            return keys;
        }
        public int[] StringToArrey(string keyString)
        {
            int[] keys = new int[(keyString.Length + 1) / 2];
            for (int i = 0, j = 0; i < keyString.Length; i++)
            {
                if (keyString[i] >= 49 && keyString[i] <= 57)//mybe(keyString[i] >= (char)minRange && keyString[i] <=  (char)maxRange)
                {
                    Int32.TryParse(keyString[i].ToString(), out keys[j++]);
                }
            }
            return keys;
        }
        public void GetRandomKey(int amountOfKeys)
        {
            Encryptor.keyStrength = 0;
            Random random = new Random();
            Encryptor.keys = new int[amountOfKeys];
            for (int i = 0; i < amountOfKeys; i++)
            {
                Encryptor.keys[i] = random.Next(minRange, maxRange);
            }
        }
        public static int FindStregthKey()
        {
            int i, max = maxRange;         
            for (i = 0; max > 0; i++) max /= 10;         
            return i;
        }
    }
}
