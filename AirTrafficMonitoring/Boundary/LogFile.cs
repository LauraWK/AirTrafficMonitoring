using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Interfaces;

namespace AirTrafficMonitoring.Boundary
{
   public class LogFile : ILogFile
   {
       public void LogToFile(ITrack track1, ITrack track2)
       {
           string path = Directory.GetCurrentDirectory() + "Logfile.txt";
           string text = "Planes in conflict: " + track1.Tag + " and " + track2.Tag + "\nTime of occurance: " +
                         DateTime.Now;
           File.WriteAllText(path,text);
        }
    }
}
