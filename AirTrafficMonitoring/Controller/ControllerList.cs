using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitoring.Domain;
using AirTrafficMonitoring.Interfaces;

namespace AirTrafficMonitoring.Controller
{
    public class ControllerList
    {
        private IAirspace airspace;
        private TrakcsInAirspace tracksInAirspace;

        public ControllerList()
        {
            airspace = new Airspace();
            tracksInAirspace = new TrakcsInAirspace();
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
