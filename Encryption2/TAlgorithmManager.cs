using Encryption2.FileHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encryption2;

namespace Encryption2
{
    public class TAlgorithmManager
    {
        public const int one = 1, dou = 2;
        static Validator validator = new Validator();
        static  KeyManager keyManager = new KeyManager();
        public static void CheckUserChioce(Encryptor.EncryptOptions encryptionType)
        {
            switch (encryptionType)
            {
                case Encryptor.EncryptOptions.ShiftUpEncryption:
                    Encryptor.fileEncryptor = new FileEncryptor(new ShiftUpEncryption());
                    break;
                case Encryptor.EncryptOptions.ShiftMultiplyEncryption:
                    Encryptor.fileEncryptor = new FileEncryptor(new ShiftMultiplyEncryption());
                    break;
                case Encryptor.EncryptOptions.DoubleEncryption:
                    GetDoubleTAlgorithm();
                    break;
                case Encryptor.EncryptOptions.RepeatEncryption:
                    Encryptor.fileEncryptor = new FileEncryptor(new RepeatEncryption(GetEncryptionAlgorithm()));
                    break;

            }
        }
        public static void GetDoubleTAlgorithm()// for Double Encryption 
        {
            Encryptor.EncryptOptions encryptionType = (Encryptor.EncryptOptions)validator.GetValidChoice(
                (int)Encryptor.EncryptOptions.ShiftUpEncryption,
                (int)Encryptor.EncryptOptions.ShiftMultiplyEncryption,
                "Choose: \n" + (int)Encryptor.EncryptOptions.ShiftUpEncryption + "-Up \n" +
                (int)Encryptor.EncryptOptions.ShiftMultiplyEncryption + "-Multiply \n");

            switch (encryptionType)
            {
                case Encryptor.EncryptOptions.ShiftUpEncryption:
                    Encryptor.fileEncryptor = new FileEncryptor(new DoubleEncryption<ShiftUpEncryption>());
                    break;
                case Encryptor.EncryptOptions.ShiftMultiplyEncryption:
                    Encryptor.fileEncryptor = new FileEncryptor(new DoubleEncryption<ShiftMultiplyEncryption>());
                    break;
                default: throw new Exception();
            }
        }

        public static IEncryptionAlgoritem GetEncryptionAlgorithm()// for Reapet Encryption
        {
            Encryptor.EncryptOptions encryptionType = (Encryptor.EncryptOptions)validator.GetValidChoice(
                (int)Encryptor.EncryptOptions.ShiftUpEncryption,
                (int)Encryptor.EncryptOptions.ShiftMultiplyEncryption,
                "Choose: \n" + (int)Encryptor.EncryptOptions.ShiftUpEncryption + "-Up \n" +
                (int)Encryptor.EncryptOptions.ShiftMultiplyEncryption + "-Multiply \n");

            switch (encryptionType)
            {
                case Encryptor.EncryptOptions.ShiftUpEncryption:
                    return new ShiftUpEncryption();
                case Encryptor.EncryptOptions.ShiftMultiplyEncryption:
                    return new ShiftMultiplyEncryption();
                default: throw new Exception();
            }
        }
        public static void CreateKeyArr(Encryptor.EncryptOptions encryptType)
        {
            switch (encryptType)
            {
                case Encryptor.EncryptOptions.ShiftUpEncryption:
                    keyManager.GetRandomKey(one);
                    break;
                case Encryptor.EncryptOptions.ShiftMultiplyEncryption:
                    keyManager.GetRandomKey(one);
                    break;
                case Encryptor.EncryptOptions.DoubleEncryption:
                    RepeatEncryption.Iteration = dou;
                    keyManager.GetRandomKey(dou);
                    break;
                case Encryptor.EncryptOptions.RepeatEncryption:                 
                    RepeatEncryption.Iteration= validator.GetValidNumOfIteration();
                    keyManager.GetRandomKey(RepeatEncryption.Iteration);
                    break;
            }
        }
    }
}
