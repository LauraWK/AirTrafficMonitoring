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
        private SortingPlanesController _sortingController;

        public TracksInAirspaceController()
        {
            airspace = new Airspace();
            _sortingController = new SortingPlanesController();
        }

        public void AddToList(ITrack track)
        {
            if (airspace.DefineAirspace(track))
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
