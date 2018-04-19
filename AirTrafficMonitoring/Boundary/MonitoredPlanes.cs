using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Domain;
using AirTrafficMonitoring.Interfaces;

namespace AirTrafficMonitoring.Boundary
{
    public class MonitoredPlanes : SubjectMonitoredPlanes
    {
        
        public void HandleSeperationEvents(ITrack track1, ITrack track2)
        {
            if (Math.Abs(track1.XCoordinate-track2.XCoordinate) < 300 && Math.Abs(track1.YCoordinate-track2.YCoordinate) < 300
                && Math.Abs(track1.Altitude - track2.Altitude) < 5000)
            {
                
                Notify(track1, track2);
            }
        }
    }
}
