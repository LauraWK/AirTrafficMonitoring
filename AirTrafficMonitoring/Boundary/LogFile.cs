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
     
       public void LogToFile(TextWriter w, ITrack track1, ITrack track2)
        {
            w.Write("Planes in conflict: ");
            w.WriteLine("{0}"+" and "+"{1}", track1.Tag, track2.Tag);
            w.Write("Time of occurance: ");
            w.WriteLine("{0}", DateTime.Now);

        }
    }
}
