using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Interfaces;

namespace AirTrafficMonitoring.Boundary
{
    public class SeperationEvent : ISeperationEvent
    {
        private MonitoredPlanes _monior;
        private ILogFile _logFile;
        private IDisplay _display;
        private ILogFile _logfile;
        

        public SeperationEvent(MonitoredPlanes monitor,IDisplay display, ILogFile logfile)
        {
            _monior = monitor;
            _display = display;
            _monior.Attach(this);
            _logFile = logfile;
        }

        public void Update(ITrack track1, ITrack track2)
        {
            _logFile.LogToFile(track1, track2);
            _display.ShowSeperationEvent(track1,track2);
        }




      
    }
}
