using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring.Boundary
{
   public class LogFile
   {
       private SeperationEvent _seperation;
        public LogFile(SeperationEvent seperation)
        {
            _seperation = seperation;
        }
       public void LogToFile(TextWriter w)
        {
            w.Write("Planes in conflict: ");
            w.WriteLine("{0}"+" and "+"{1}", _seperation.TagTrack1, _seperation.TagTrack2);
            w.Write("Time of occurance: ");
            w.WriteLine("{0}",_seperation.TimeOfOccurance);

        }
    }
}
