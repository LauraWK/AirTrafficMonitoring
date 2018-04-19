using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Boundary;

namespace AirTrafficMonitoring.Domain
{
    public class Display : SubjectMonitoredPlanes
    {
        public void ShowTrack(ITrack _track)
        {
            Console.WriteLine("Tag: " + _track.Tag + " XCoordinate: " + _track.XCoordinate + " YCoordinate: " + _track.YCoordinate + " Altitude: " + _track.Altitude + " Timestamp: " + _track.Timestamp);

        }
    }
}
