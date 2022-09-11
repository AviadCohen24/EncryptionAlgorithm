using Encryption2.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption2.FileHandler
{
    public class FileEncryptor
    {
        KeyManager keyManager = new KeyManager();
        IEncryptionAlgoritem encryptType;

        public FileEncryptor(IEncryptionAlgoritem encryptType)
        {
            this.encryptType = encryptType;
        }     
        public void EncryptFile(string originalFilePath, string outputlFilePath, int[] key)
        {
            string KeyPath = FileManager.CreateKeyPath(originalFilePath, "\\Key.");
            FileIO.Write(outputlFilePath, encryptType.Encrypt(FileIO.Read(originalFilePath), key));
            FileIO.Write(KeyPath, (string.Join(" ", key)));
            ConsoleIO.Write("Your output saved in this address: " + outputlFilePath);
            ConsoleIO.Write("Your key saved in this address: " + KeyPath);
        }
        public void DecryptFile(string encryptFilePath, string outputlFilePath)
        {
            int[] key = keyManager.GetValidKey();
            outputlFilePath = FileManager.CreatePath(encryptFilePath, "_decrypt.");
            FileIO.Write(outputlFilePath, encryptType.Decrypt(FileIO.Read(encryptFilePath), key));
            ConsoleIO.Write("Your output saved in this address: " + outputlFilePath);
        }
    }
}
