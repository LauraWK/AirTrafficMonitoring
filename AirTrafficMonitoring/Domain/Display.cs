using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Interfaces;

namespace AirTrafficMonitoring.Domain
{
    public class Display : IDisplay
    {
        public void ShowTrack(ITrack _track)
        {
            Console.WriteLine("Tag: " + _track.Tag + " XCoordinate: " + _track.XCoordinate + " YCoordinate: " + _track.YCoordinate + " Altitude: " + _track.Altitude + " Timestamp: " + _track.Timestamp + " Velocity: " + _track.Velocity + " Course: " + _track.CompassCourse);

        }

        public void ShowSeperationEvent(ITrack track1, ITrack track2)
        {
            Console.WriteLine("Alarm!!!" + "\n" + "Planes in conflict " + track1.Tag + "and" + track2.Tag + "\n" + "Time of occurance: " + DateTime.Now);
        }
    }
}
