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
    class Validator
    {
        string errorMassage = "invalid input, try again.";
        public string GetValidInput(string message)
        {
            var input = ConsoleIO.Read(message);
            while (input == null || input == String.Empty)
            {
                input = ConsoleIO.Read(message);
            }
            return input;
        }

        public int GetValidChoice(int minRange, int maxRange, string menu)
        {
            int choice;
            Int32.TryParse(GetValidInput(menu), out choice);
            while (choice < minRange || choice > maxRange)
            {
                ConsoleIO.Write(errorMassage);
                Int32.TryParse(GetValidInput(menu), out choice);
            }
            return choice;
        }

        public string GetValidFilePath(string message)
        {
            FileNotFoundException e = new FileNotFoundException();
            var path = ConsoleIO.Read(message);
            while (!File.Exists(path))
            {           
               ConsoleIO.Write(e.Message);
               path = ConsoleIO.Read(message);
            }
            return path;
        }
    
        public int GetValidNumOfIteration()
        {
            int iteration;
            Int32.TryParse(GetValidInput("enter amount of iteration "), out iteration);
            while (iteration < 0 || iteration > Int16.MaxValue)
            {
                Console.WriteLine(errorMassage);
                Int32.TryParse(GetValidInput("enter amount of iteration "), out iteration);
            }
            return iteration;
        }
    }
}
