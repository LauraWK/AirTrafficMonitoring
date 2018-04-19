using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring.Boundary
{
    public class SeperationEvent : SubjectMonitoredPlanes
    {
        public string TimeOfOccurance { get; set; }
        public string TagTrack1 { get; set; }
        public string TagTrack2 { get; set; }


      
    }
}
