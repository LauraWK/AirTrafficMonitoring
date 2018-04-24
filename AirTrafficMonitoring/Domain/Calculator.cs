using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring.Domain
{
    public class Calculator : ICalculator
    {
        public double DetermineVelocity(ITrack track1, ITrack track2)
        {
            TimeSpan timediff = track2.Timestamp.Subtract(track1.Timestamp);
            double secdiff = timediff.TotalSeconds;
            var distance = Math.Sqrt(Math.Pow((track1.YCoordinate - track2.YCoordinate), 2) +
                                     Math.Pow((track2.XCoordinate - track1.XCoordinate), 2));
            var velocity = distance / Math.Abs(Convert.ToDouble(secdiff));

            return velocity;

        }


        public double Direction(ITrack track1, ITrack track2)
        {

            double diffXCoordinate = track2.XCoordinate - track1.XCoordinate;

            double diffYCoordinate = track2.YCoordinate - track1.YCoordinate;

            double angleInDegrees = 0;

                if (diffXCoordinate == 0)
            {
                angleInDegrees = diffYCoordinate > 0 ? 0 : 180;
            }
            else
            {
                double angleInRadians = Math.Atan2(diffYCoordinate, diffXCoordinate);
                angleInDegrees = angleInRadians * (180 / Math.PI);

                angleInDegrees = 90 - angleInDegrees;
                if (angleInDegrees < 0) angleInDegrees += 360;
            }

            return angleInDegrees;
        }
    }
}
