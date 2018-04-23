using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Interfaces;

namespace AirTrafficMonitoring
{
    public class CompassCourse : ICompassCourse
    {
        public double Direction(ITrack track)
        {
            //ved nord lig 0 er længden til kanten lig 90.000 - det ses som en vektor (0,90000) som vi beregner vinkel med
            double angleInRadians = Math.Atan2(track.YCoordinate, track.XCoordinate) - Math.Atan2(90000, 0);

            double angleInDegrees = Math.Abs(angleInRadians / (180 / Math.PI));

            return angleInDegrees;

        }
    }
}
