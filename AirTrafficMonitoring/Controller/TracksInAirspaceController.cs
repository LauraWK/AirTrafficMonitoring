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
        private IAirspace _airspace;
        private SortingPlanesController _sortingController;

        public TracksInAirspaceController(IAirspace airspace, SortingPlanesController sortingcontroller)
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
