using Encryption2.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption2
{
    public class Time
    {
        protected static  Stopwatch stopWatch = new Stopwatch();
        public static void StartTimer()
        {
            stopWatch.Start();
        }
        public static void StopTimer(string algorithmType)
        {             
            stopWatch.Stop();
            ConsoleIO.Write(String.Format("espaled MilliSeconds for {0}:{1} ", algorithmType, stopWatch.ElapsedMilliseconds));

        }
    }
}
