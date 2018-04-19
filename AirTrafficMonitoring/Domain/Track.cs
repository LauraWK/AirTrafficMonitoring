using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class Track : ITrack
    {
        public string Tag { get; set; }
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public int Altitude { get; set; }
        public DateTime Timestamp { get; set; }
        public double velocity { get; set; }
        public double compassCourse { get; set; }

        public Track()
        {
            XCoordinate = 0;
            YCoordinate = 0;
            Altitude = 0;
            velocity = 0;
            compassCourse = 0;


        }
        
    }
}
