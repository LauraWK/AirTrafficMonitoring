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
        private ILogFile _logFile;
        private TextWriter writer;
        private IDisplay _display;
        

        public SeperationEvent(MonitoredPlanes monitor)
        {
            _monitor = monitor;
            monitor.Attach(this);
        }

        public void Update(ITrack track1, ITrack track2)
        {
            _logFile.LogToFile(writer, track1, track2);
            _display.ShowSeperationEvent(track1,track2);
        }




      
    }
}
