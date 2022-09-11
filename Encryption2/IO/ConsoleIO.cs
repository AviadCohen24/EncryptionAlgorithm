using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption2.IO
{
    public class ConsoleIO //: IIO
    {
        public static string Read(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        public static void Write(string messege)
        {
            Console.WriteLine(messege);
        }       
    }
}
