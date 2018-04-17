using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring.Domain
{
    public class Display
    {
        public void ShowTrack(ITrack _track)
        {
            Console.WriteLine("Tag: " + _track.Tag + " XCoordinate: " + _track.XCoordinate + " YCoordinate: " + _track.YCoordinate + " Altitude: " + _track.Altitude + " Timestamp: " + _track.Timestamp);

        }
    }
}
