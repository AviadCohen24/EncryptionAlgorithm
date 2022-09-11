using Encryption2.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Encryption2.FileHandler;

namespace Encryption2
{

    public class Encryptor
    {
        public enum UserOptions { Encrypt = 1, Decrypt };
        public enum EncryptOptions { ShiftUpEncryption = 1, ShiftMultiplyEncryption, DoubleEncryption, RepeatEncryption };
        public string outputlFilePath, originalFilePath, keyPath;
        public static string encryptMenu = "Choose: \n" + (int)EncryptOptions.ShiftUpEncryption + "-Up \n"
            + (int)EncryptOptions.ShiftMultiplyEncryption + "-Multiply \n"
            + (int)EncryptOptions.DoubleEncryption + "-Double \n"
            + (int)EncryptOptions.RepeatEncryption + "-Repeat \n";
        public static string menu = "Choose: \n" + (int)UserOptions.Encrypt + "-Encrypt \n"
            + (int)UserOptions.Decrypt + "-Decrypt \n" + "Ctrl C -Exit";
        public static int[] keys;
        public static int keyStrength;
        Validator validator = new Validator();
        public static FileEncryptor fileEncryptor;
        KeyStrengthCompare keyStrengthCompare = new KeyStrengthCompare();

        public void Run()
        {
            var userChoice = (UserOptions)validator.GetValidChoice((int)UserOptions.Encrypt,
                UserOptions.GetNames(typeof(UserOptions)).Length, menu);
            EncryptOptions encryptionType;
            switch (userChoice)
            {
                case UserOptions.Encrypt:
                    encryptionType = (EncryptOptions)validator.GetValidChoice(
                      (int)EncryptOptions.ShiftUpEncryption,
                      EncryptOptions.GetNames(typeof(EncryptOptions)).Length, encryptMenu);
                    originalFilePath = validator.GetValidFilePath("enter your file location");
                    outputlFilePath = FileManager.CreatePath(originalFilePath, "_encrypt.");
                    TAlgorithmManager.CheckUserChioce(encryptionType);
                    TAlgorithmManager.CreateKeyArr(encryptionType);
                    fileEncryptor.EncryptFile(originalFilePath, outputlFilePath, keys);
                    break;
                case UserOptions.Decrypt:
                    encryptionType = (EncryptOptions)validator.GetValidChoice(
                        (int)EncryptOptions.ShiftUpEncryption,
                        EncryptOptions.GetNames(typeof(EncryptOptions)).Length, encryptMenu);
                    originalFilePath = validator.GetValidFilePath("enter your file location");
                    outputlFilePath = FileManager.CreatePath(originalFilePath, "_decrypt.");
                    TAlgorithmManager.CheckUserChioce(encryptionType);
                    fileEncryptor.DecryptFile(originalFilePath, outputlFilePath);
                    break;
                default: throw new Exception();
            }
            ConsoleIO.Write("Done:)\n");

        }

        public void RunKeyStrTest()
        {
            originalFilePath = validator.GetValidFilePath("enter your file location");
            outputlFilePath = FileManager.CreatePath(originalFilePath, "_decrypt.");
            PrintTalgorithm(EncryptOptions.ShiftUpEncryption);
            PrintTalgorithm(EncryptOptions.RepeatEncryption);
            ConsoleIO.Write(keyStrengthCompare.Compare(new ShiftUpEncryption(), new RepeatEncryption()).ToString());
        }
        public void PrintTalgorithm(EncryptOptions encryptOptions)
        {
            TAlgorithmManager.CheckUserChioce(encryptOptions);
            TAlgorithmManager.CreateKeyArr(encryptOptions);
            Time.StartTimer();
            fileEncryptor.EncryptFile(originalFilePath, outputlFilePath, keys);
            Time.StopTimer(encryptOptions.ToString());
        }
    }
}
