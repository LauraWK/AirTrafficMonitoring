using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitoring.Interfaces
{
    public interface ISortingPlanesController
    {
        void MatchTracks(ITrack track);
        void removeTrack(ITrack track);
    }
}
