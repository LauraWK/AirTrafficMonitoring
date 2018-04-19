using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring.Interfaces
{
    interface IVelocity
    {
        double DetermineVelocity(ITrack track1, ITrack track2);
    }
}
