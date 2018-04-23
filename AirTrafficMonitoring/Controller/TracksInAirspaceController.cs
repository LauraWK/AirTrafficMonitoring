using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Domain;
using AirTrafficMonitoring.Interfaces;

namespace AirTrafficMonitoring.Controller
{
    public class TracksInAirspaceController
    {
        private IAirspace airspace;
        private SortingPlanesController tracksInAirspace;

        public TracksInAirspaceController()
        {
            airspace = new Airspace();
            tracksInAirspace = new SortingPlanesController();
        }

        public void AddToList(ITrack track)
        {
            if (airspace.DefineAirspace(track))
            {
                tracksInAirspace.MatchTracks(track);
            }
            else
            {
                tracksInAirspace.removeTrack(track);
            }
        }
    }
}
