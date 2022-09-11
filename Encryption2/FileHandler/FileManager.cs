using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption2.FileHandler
{
    class FileManager
    {      
        public static string CreatePath(string path, string strAdd)
        {
            return String.Format("{0}{1}{2}", path.Split('.')[0], strAdd, path.Split('.')[1]);
        }
        public static string CreateKeyPath(string path, string strAdd)
        {
            return String.Format("{0}{1}{2}", Path.GetDirectoryName(path), strAdd, path.Split('.')[1]);
        }
    }
}
