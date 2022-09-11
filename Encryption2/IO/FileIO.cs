using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Encryption2.IO
{

    public class FileIO //:IIO
    {
        public static string Read(string path)
        {
            return File.ReadAllText(path);
        }

        public static void Write(string path, string txt)
        {
            File.WriteAllText(path, txt);
        }
    }
}
