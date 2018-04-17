using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring
{
    public class CompassCourse
    {
        public int North { get; set; }
        public int East { get; set; }
        public int South { get; set; }
        public int West { get; set; }
        public int NorthEast { get; set; }
        public int SouthEast { get; set; }
        public int SouthWest { get; set; }
        public int NorthWest { get; set; }

        public int Undefined { get; set; }

        public void CompassCourse1()
        {
            North = 0;
            East = 2;
            South = 4;
            West = 6;
            NorthEast = 1;
            SouthEast = 3;
            SouthWest = 5;
            NorthWest = 7;
            Undefined = -1;
        }

        public int Direction(ITrack track1,ITrack track2)
        {
            double angle = Math.Atan2(track2.YCoordinate - track1.YCoordinate, track2.XCoordinate - track1.XCoordinate);
            angle += Math.PI;
            angle /= Math.PI / 4;
            int halfQuarter = Convert.ToInt32(angle);
            halfQuarter %= 8;

            return halfQuarter;
        }

    }
}
