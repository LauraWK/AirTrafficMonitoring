using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Interfaces;

namespace AirTrafficMonitoring.Domain
{
    public class Airspace : IAirspace
    {
    

        public bool DefineAirspace(ITrack track)
        {
            if (track.XCoordinate >= 10000 || track.XCoordinate <= 90000 && track.YCoordinate >= 10000 ||
                track.YCoordinate >= 90000)
            {
                if (track.Altitude >= 500 && track.Altitude <= 20000)
                {   
                    return true;
                }
                return false;
 
            }
            return false;
        }

    }
}
