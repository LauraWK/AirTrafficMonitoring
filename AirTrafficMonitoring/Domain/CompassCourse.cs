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

            double diffXCoordinate = track.XCoordinate - 90000;
                
            double diffYCoordinate = track.YCoordinate- 0;

            double angleInRadians = Math.Atan(diffYCoordinate/diffXCoordinate);

            double angleInDegrees = Math.Abs(angleInRadians / (180 / Math.PI));

            if (diffXCoordinate < 0 || diffYCoordinate < 0)
            {
                angleInDegrees += 180;
            }

            if (diffXCoordinate > 0 && diffYCoordinate < 0)
            {
                angleInDegrees -= 180;
            }

            if (angleInDegrees < 0)
            {
                angleInDegrees += 360;
            }
                

            return angleInDegrees;

        }
    }
}
