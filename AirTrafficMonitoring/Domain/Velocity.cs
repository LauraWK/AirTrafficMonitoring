using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Interfaces;

namespace AirTrafficMonitoring.Domain
{
    public class Velocity : IVelocity
    {
        

        public double DetermineVelocity(ITrack track1, ITrack track2)
        {
            TimeSpan timediff = track2.Timestamp.Subtract(track1.Timestamp);
            double secdiff = timediff.TotalSeconds;
            var distance = Math.Sqrt(Math.Pow((track1.YCoordinate - track2.YCoordinate),2) +
                                     Math.Pow((track2.XCoordinate - track1.XCoordinate),2));
            var velocity = distance / Math.Abs(Convert.ToDouble(secdiff));

            return velocity;

        }

    }
}
