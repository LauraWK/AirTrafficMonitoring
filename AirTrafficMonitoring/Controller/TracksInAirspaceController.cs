using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Domain;
using AirTrafficMonitoring.Interfaces;

namespace AirTrafficMonitoring.Controller
{
    public class TracksInAirspaceController : ITracksInAirSpaceController
    {
        private IAirspace _airspace;
        private ISortingPlanesController _sortingController;

        public TracksInAirspaceController(IAirspace airspace, ISortingPlanesController sortingcontroller)
        {
            _airspace = airspace;
            _sortingController = sortingcontroller;

        }

        public void AddToList(ITrack track)
        {
            if (_airspace.DefineAirspace(track))
            {
                _sortingController.MatchTracks(track);
            }
            else
            {
                _sortingController.removeTrack(track);
            }
        }
    }
}
