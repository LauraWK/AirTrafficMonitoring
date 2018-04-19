using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Interfaces;

namespace AirTrafficMonitoring.Boundary
{
    public class SeperationEvent : IMonitoredPlanes
    {
        private MonitoredPlanes _monitor;
        private LogFile _logFile;
        private TextWriter writer;
        

        public SeperationEvent(MonitoredPlanes monitor)
        {
            _monitor = monitor;
            monitor.Attach(this);
        }

        public void Update(ITrack track1, ITrack track2)
        {
            _logFile.LogToFile(writer, track1, track2);
        }




      
    }
}
