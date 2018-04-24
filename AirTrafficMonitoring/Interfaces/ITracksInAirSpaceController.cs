using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring.Interfaces
{
    public interface ITracksInAirSpaceController
    {
        void AddToList(ITrack track);
    }
}
